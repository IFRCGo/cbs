/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Infrastructure.Application;

namespace Infrastructure.Events
{
    /// <summary>
    /// Represents the origin of an <see cref="IEvent"/>
    /// </summary>
    public class EventOrigin
    {
        /// <summary>
        /// The unknown origin
        /// </summary>
        public static readonly EventOrigin Unknown = EventOrigin.FromStrings("Unknown", "Unknown");

        /// <summary>
        /// Create an <see cref="EventOrigin"/> from string representations
        /// </summary>
        /// <param name="boundedContext"><see cref="BoundedContext"/> string representation</param>
        /// <param name="feature"><see cref="Feature"/> string representation</param>
        /// <returns>An <see cref="EventOrigin"/> instance</returns>
        public static EventOrigin   FromStrings(string boundedContext, string feature)
        {
            return new EventOrigin(boundedContext, feature);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EventOrigin"/>
        /// </summary>
        /// <param name="boundedContext"><see cref="BoundedContext"/> as part of the origin</param>
        /// <param name="feature"><see cref="Feature"/> as part of the origin</param>
        public EventOrigin(BoundedContext boundedContext, Feature feature)
        {
            BoundedContext = boundedContext;
            Feature = feature;
        }

        /// <summary>
        /// Gets the <see cref="BoundedContext"/> for the <see cref="EventOrigin"/>
        /// </summary>
        /// <returns><see cref="BoundedContext"/></returns>
        public BoundedContext BoundedContext { get; }

        /// <summary>
        /// Gets the <see cref="Feature"/> for the <see cref="EventOrigin"/>
        /// </summary>
        /// <returns><see cref="Feature"/></returns>
        public Feature Feature { get; }
    }
}