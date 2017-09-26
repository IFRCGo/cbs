/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Infrastructure.Events
{
    /// <summary>
    /// Represents an implementation of <see cref="IEventEnvelopeProducer"/>
    /// </summary>
    public class EventEnvelopeProducer : IEventEnvelopeProducer
    {
        /// <inheritdoc/>
        public EventEnvelope CreateFor(EventOrigin origin, IEvent @event)
        {
            return new EventEnvelope();
        }
    }
}