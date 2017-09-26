/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;

namespace Infrastructure.Events
{
    /// <summary>
    /// Represents an implementation of <see cref="IEventEmitter"/>
    /// </summary>
    public class EventEmitter : IEventEmitter
    {
        /// <inheritdoc/>
        public void Emit(EventOrigin origin, IEvent @event)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public void Emit(EventOrigin origin, IEnumerable<IEvent> events)
        {
            throw new System.NotImplementedException();
        }
    }
}