/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using doLittle.Concepts;

namespace Events
{
    /// <summary>
    /// Represents a sequence number for an event
    /// </summary>
    public class EventSequenceNumber : ConceptAs<int>
    {
        /// <summary>
        /// Implicitly convert from an <see cref="int"/> representation to <see cref="EventSequenceNumber"/>
        /// </summary>
        /// <param name="number">Sequence number as <see cref="int"/></param>
        public static implicit operator EventSequenceNumber(int number)
        {
            return new EventSequenceNumber { Value = number };
        }
        
    }
}