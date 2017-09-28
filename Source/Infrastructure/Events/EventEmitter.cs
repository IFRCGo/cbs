/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using doLittle.Collections;
using Infrastructure.Application;

namespace Infrastructure.Events
{
    /// <summary>
    /// Represents an implementation of <see cref="IEventEmitter"/>
    /// </summary>
    public class EventEmitter : IEventEmitter
    {
        readonly ApplicationInformation _applicationInformation;
        readonly IEventPublisher _eventPublisher;
        readonly IEventProcessors _eventProcessors;
        readonly IEventEnvelopeProducer _eventEnvelopeProducer;
        readonly IEventStore _eventStore;
        

        /// <summary>
        /// Initializes a new instance of <see cref="EventEmitter"/>
        /// </summary>
        /// <param name="applicationInformation"></param>
        /// <param name="eventEnvelopeProducer"></param>
        /// <param name="eventPublisher"></param>
        /// <param name="eventStore"></param>
        /// <param name="eventProcessors"></param>
        public EventEmitter(
            ApplicationInformation applicationInformation,
            IEventEnvelopeProducer eventEnvelopeProducer,
            IEventPublisher eventPublisher,
            IEventStore eventStore,
            IEventProcessors eventProcessors)
        {
            _applicationInformation = applicationInformation;
            _eventPublisher = eventPublisher;
            _eventProcessors = eventProcessors;
            _eventEnvelopeProducer = eventEnvelopeProducer;
            _eventStore = eventStore;
        }

        /// <inheritdoc/>
        public void Emit(Feature feature, IEvent @event)
        {
            Emit(feature, new[] { @event });
        }

        /// <inheritdoc/>
        public void Emit(Feature feature, IEnumerable<IEvent> events)
        {
            var origin = new EventOrigin(_applicationInformation.BoundedContext, feature);

            var envelopes = events.Select(@event => _eventEnvelopeProducer.CreateFor(origin, @event));
            _eventStore.Save(envelopes);

            Parallel.Invoke(
                () => _eventPublisher.Publish(envelopes),
                () => _eventProcessors.Process(envelopes)
            );
        }
    }
}