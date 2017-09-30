/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Read
{
    /// <summary>
    /// Represents a <see cref="PhoneNumber"/>
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Initializes a new instance of <see cref="PhoneNumber"/>
        /// </summary>
        /// <param name="number"></param>
        /// <remarks>
        /// Only use / as separator
        /// </remarks>
        public PhoneNumber(string number)
        {
            Number = number;
        }

        /// <summary>
        /// Gets the actual Phonenumber
        /// </summary>
        /// <returns></returns>
        public string Number { get; }

        /// <summary>
        /// Implicitly convert from a string representation of a Phonenumber <see cref="PhoneNumber"/>
        /// </summary>
        /// <param name="number">The phone number</param>
        public static implicit operator PhoneNumber(string number)
        {
            return new PhoneNumber(number);
        }
    }
}