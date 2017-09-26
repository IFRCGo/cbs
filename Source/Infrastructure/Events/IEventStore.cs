/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;

namespace Infrastructure.Events
{
    /// <summary>
    /// Defines a store for holding <see cref="IEvent">events</see>
    /// </summary>
    public interface IEventStore
    {
        /// <summary>
        /// Save a collection of <see cref="IEvent">events</see>
        /// </summary>
        /// <param name="events"><see cref="IEvent">Events</see> to save</param>
        void Save(IEnumerable<EventEnvelope> events);
    }
}