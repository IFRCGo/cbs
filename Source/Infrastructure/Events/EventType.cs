/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using doLittle.Concepts;

namespace Infrastructure.Events
{
    /// <summary>
    /// Represents the specific type of an event
    /// </summary>
    public class EventType : ConceptAs<string>
    {

        /// <summary>
        /// Implicitly convert from a string representation of an type of event to <see cref="EventType"/>
        /// </summary>
        /// <param name="type">String representation of an event type</param>
        public static implicit operator EventType(string type)
        {
            return new EventType { Value = type };
        }
    }
}