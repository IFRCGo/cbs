/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;

namespace Infrastructure.Events
{
    /// <summary>
    /// Defines a system that can deal with <see cref="IEventProcessor">event processors</see>
    /// </summary>
    public interface IEventProcessors
    {
        /// <summary>
        /// Process an <see cref="IEvent"/> from a full <see cref="EventEnvelope"/>
        /// </summary>
        /// <param name="event"><see cref="EventEnvelope"/> holding the <see cref="IEvent"/> and more details</param>
        void Process(EventEnvelope @event);

        /// <summary>
        /// Process a collection of <see cref="IEvent"/> from a full <see cref="EventEnvelope"/>
        /// </summary>
        /// <param name="events"><see cref="EventEnvelope">Envelopes</see> holding the <see cref="IEvent"/> and more details</param>
        void Process(IEnumerable<EventEnvelope> events);
    }
}