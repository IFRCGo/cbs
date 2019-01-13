/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Concepts;

namespace Concepts
{
    public class PhoneNumber : Value<PhoneNumber>
    {
        public string Value { get; private set; }

        public PhoneNumber(string value)
        {
            Value = value;
        }
        
        //TODO: This value should default to false after the MVP and when there is logic for phone number confirmation
        public bool Confirmed { get; private set; } = true;

        public bool IsValid => ! Value.Contains(" ");
        
        public override bool Equals(object obj)
        {
            var item = obj as PhoneNumber;

            if (item == null)
            {
                return false;
            }

            return Value.Equals(item.Value);
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }        
    }
}