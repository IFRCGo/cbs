/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Concepts;

namespace Concepts.DataCollector
{
    /// <summary>
    /// Represents a <see cref="PhoneNumber"/>
    /// </summary>
    public class PhoneNumber : ConceptAs<string>
    {
        /// <summary>
        /// Implicitly convert from a string representation of a Phonenumber <see cref="PhoneNumber"/>
        /// </summary>
        /// <param name="number">The phone number</param>
        public static implicit operator PhoneNumber(string number)
        {
            return new PhoneNumber { Value = number };
        }
    }
}