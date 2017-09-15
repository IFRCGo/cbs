/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Domain;

namespace Events
{
    /// <summary>
    /// Represents the origin of an <see cref="IEvent"/>
    /// </summary>
    public class EventOrigin
    {
        /// <summary>
        /// Initializes a new instance of <see cref="EventOrigin"/>
        /// </summary>
        /// <param name="boundedContext"><see cref="BoundedContext"/> as part of the origin</param>
        public EventOrigin(BoundedContext boundedContext)
        {
            BoundedContext = boundedContext;
        }

        /// <summary>
        /// Gets the <see cref="BoundedContext"/> for the <see cref="EventOrigin"/>
        /// </summary>
        /// <returns><see cref="BoundedContext"/></returns>
        public BoundedContext BoundedContext { get; }
    }
}