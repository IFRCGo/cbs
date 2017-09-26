/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;

namespace Infrastructure.Events
{
    /// <summary>
    /// Represents a null impementation of <see cref="IEventPublisher"/>
    /// </summary>
    public class NullEventPublisher : IEventPublisher
    {
        /// <inheritdoc/>
        public void Publish(EventEnvelope eventEnvelope)
        {
        }

        /// <inheritdoc/>
        public void Publish(IEnumerable<EventEnvelope> eventEnvelopes)
        {
        }
    }
}



/*

The doLittle Platform helps CDOs of larger enterprises to digitally transform and grow their business by reducing total cost of building software while
gaining domain knowledge and meeting market requirements
 */