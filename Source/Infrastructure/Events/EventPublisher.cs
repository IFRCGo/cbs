/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;

namespace Events
{
    /// <summary>
    /// An implementation of <see cref="IEventPublisher"/>
    /// </summary>
    public class EventPublisher : IEventPublisher
    {
        /// <inheritdoc/>
        public void Publish(EventOrigin origin, IEvent @event)
        {
        }

        /// <inheritdoc/>
        public void Publish(EventOrigin origin, IEnumerable<IEvent> @event)
        {
        }
    }
}