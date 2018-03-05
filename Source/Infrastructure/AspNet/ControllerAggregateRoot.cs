/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using doLittle.Runtime.Events;

namespace Infrastructure.AspNet
{
    /// <summary>
    /// Represents an aggregate root <see cref="EventSource">event source</see>
    /// </summary>
    public class ControllerAggregateRoot : EventSource
    {
        /// <summary>
        /// Initializes a new instance
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ControllerAggregateRoot(EventSourceId id) : base(id)
        {
        }
    }
}