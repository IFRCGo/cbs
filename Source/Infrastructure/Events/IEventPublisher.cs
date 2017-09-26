/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;

namespace Infrastructure.Events
{
    /// <summary>
    /// Defines a system that is capable of publishing events
    /// </summary>
    public interface IEventPublisher
    {
        /// <summary>
        /// Publish an event
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="eventEnvelope"></param>
        void Publish(EventOrigin origin, EventEnvelope eventEnvelope);

        /// <summary>
        /// Publish a set of events
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="eventEnvelopes"></param>
        void Publish(EventOrigin origin, IEnumerable<EventEnvelope> eventEnvelopes);
    }
}