/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Infrastructure.Events;

namespace Infrastructure.Events
{
    /// <inheritdoc />
    /// <summary>
    /// Represents an implementation of <see cref="T:Infrastructure.Events.IEventStore" />
    /// </summary>
    public class NullEventStore : IEventStore
    {
        /// <inheritdoc/>
        public void Save(IEnumerable<EventEnvelope> events)
        {
            
        }

        /// <inheritdoc />
        public IEnumerable<EventEnvelope> Replay()
        {
            return new List<EventEnvelope>();
        }
    }
}