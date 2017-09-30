/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Events
{
    /// <inheritdoc />
    /// <summary>
    /// Event store that can be used for local development. Writes events to disk
    /// </summary>
    public class FileEventStore : IEventStore
    {
        /// <inheritdoc/>
        public void Save(IEnumerable<EventEnvelope> events)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public IEnumerable<EventEnvelope> Replay()
        {
            throw new NotImplementedException();
        }
    }
}
