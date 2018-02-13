/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;

namespace TextMessaging
{
    public class TextMessageParsingResult
    {
        readonly List<string> _errorMessages = new List<string>();
        public TextMessageParsingResult(IEnumerable<TextMessageFragment> fragments)
        {
            Fragments = fragments;
            Numbers = fragments.Where(fragment => fragment.IsNumber).Select(fragment => fragment.AsNumber).ToArray();
            HasMultipleCases = Numbers.Length == 5;

            ValidateAllFragmentsHasValue();
            ValidateThatIsCorrectMessage();
        }

        public IEnumerable<TextMessageFragment> Fragments { get; }

        public int[] Numbers { get; }

        public bool IsValid => ErrorMessages.Count() == 0;

        public bool HasMultipleCases { get; }

        public IEnumerable<string> ErrorMessages => _errorMessages;

        void ValidateAllFragmentsHasValue()
        {
            if( Fragments.Any(fragment => !fragment.HasValue) )
                _errorMessages.Add("Message contain one or more hashes with missing number in front or after");
        }

        void ValidateThatIsCorrectMessage()
        {
            if( !(Numbers.Length == 1 || Numbers.Length == 3 || Numbers.Length == 5) )
            {
                _errorMessages.Add("Message is in incorrect format - it should have 1, 3 or 5 numbers");
            }
                
            if(Numbers.Any(x => x < 0))
            {
                _errorMessages.Add("Negative numbers are incorrect - only positive numbers and zero is allowed");
            }

            if (Numbers.Length == 3 && ((Numbers[1] < 1 || Numbers[1] > 2) || (Numbers[2] < 1 || Numbers[2] > 2)))
            {
                _errorMessages.Add("Sex and age group must be either 1 or 2");
            }
        }
    }
}