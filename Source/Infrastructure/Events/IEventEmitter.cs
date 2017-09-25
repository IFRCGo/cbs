/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;

namespace Events
{
    /// <summary>
    /// Defines a system that is capable of emitting events
    /// </summary>
    public interface IEventEmitter
    {
        /// <summary>
        /// Emit an <see cref="IEvent"/>
        /// </summary>
        /// <param name="origin">Origin of the <see cref="IEvent"/>></param>
        /// <param name="event"><see cref="IEvent">Events</see> to emit</param>
        void Emit(EventOrigin origin, IEvent @event);

        /// <summary>
        /// Emit a collection of <see cref="IEvent">events</see>
        /// </summary>
        /// <param name="origin">Origin of the <see cref="IEvent"/>></param>
        /// <param name="events"><see cref="IEvent">Events</see> to emit</param>
        void Emit(EventOrigin origin, IEnumerable<IEvent> events);
    }
}