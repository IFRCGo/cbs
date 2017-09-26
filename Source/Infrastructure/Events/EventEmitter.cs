/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using doLittle.Collections;

namespace Infrastructure.Events
{
    /// <summary>
    /// Represents an implementation of <see cref="IEventEmitter"/>
    /// </summary>
    public class EventEmitter : IEventEmitter
    {
        readonly IEventSequenceNumberGenerator _eventSequenceNumberGenerator;
        readonly IEventPublisher _eventPublisher;
        readonly IEventProcessors _eventProcessors;

        /// <summary>
        /// Initializes a new instance of <see cref="EventEmitter"/>
        /// </summary>
        /// <param name="eventSequenceNumberGenerator"></param>
        /// <param name="eventPublisher"></param>
        /// <param name="eventProcessors"></param>
        public EventEmitter(
            IEventSequenceNumberGenerator eventSequenceNumberGenerator,
            IEventPublisher eventPublisher,
            IEventProcessors eventProcessors)
        {
            _eventSequenceNumberGenerator = eventSequenceNumberGenerator;
            _eventPublisher = eventPublisher;
            _eventProcessors = eventProcessors;
        }

        /// <inheritdoc/>
        public void Emit(EventOrigin origin, IEvent @event)
        {
            Emit(origin, new[] { @event });
        }

        /// <inheritdoc/>
        public void Emit(EventOrigin origin, IEnumerable<IEvent> events)
        {
            events.ForEach(@event =>
            {
                var sequenceNumber = _eventSequenceNumberGenerator.NextFor(origin, @event);
                

            });
        }
    }
}