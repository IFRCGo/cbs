/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;

namespace Events
{
    /// <summary>
    /// Represents a null impementation of <see cref="IEventPublisher"/>
    /// </summary>
    public class NullEventPublisher : IEventPublisher
    {
        /// <inheritdoc/>
        public void Publish(EventOrigin origin, EventEnvelope eventEnvelope)
        {
        }

        /// <inheritdoc/>
        public void Publish(EventOrigin origin, IEnumerable<EventEnvelope> eventEnvelopes)
        {
        }
    }
}