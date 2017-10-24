/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace TextMessaging
{
    public class TextMessageFragment
    {
        public TextMessageFragment(string value)
        {
            Value = value;

            var result = 0;
            IsNumber = int.TryParse(value, out result);
            AsNumber = result;

            HasValue = value.Length > 0;
        }
        public string Value { get; }

        public bool IsNumber { get; }

        public bool HasValue { get; }

        public int AsNumber { get; }
    }
}