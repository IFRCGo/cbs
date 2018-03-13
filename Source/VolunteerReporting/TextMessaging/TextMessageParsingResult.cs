/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts;
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
            ValidateAllFragmentsHasValue();
            ValidateThatIsCorrectMessage();
            PopulateMessageContent();
        }

        public IEnumerable<TextMessageFragment> Fragments { get; }
        public int[] Numbers { get; }
        public bool IsValid => ErrorMessages.Count() == 0;       
        public IEnumerable<string> ErrorMessages => _errorMessages;
        public HealthRiskReadableId HealthRiskReadableId { get; private set; }
        public int MalesAges0To4 { get; private set; }
        public int MalesAgedOver4 { get; private set; }
        public int FemalesAges0To4 { get; private set; }
        public int FemalesAgedOver4 { get; private set; }

        private void ValidateAllFragmentsHasValue()
        {
            if( Fragments.Any(fragment => !fragment.HasValue) )
                _errorMessages.Add("Message contain one or more hashes with missing number in front or after");
        }

        private void ValidateThatIsCorrectMessage()
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

        private void PopulateMessageContent()
        {
            if (!IsValid) return;
            HealthRiskReadableId = Numbers[0];

            //TODO: Validate that non human health risk has the right number
            var nonHumanHealthRisk = Numbers.Length == 1;
            if (nonHumanHealthRisk) return;

            //TODO: Add validation on health risk to ensure that human health risks actually have three valid numbers. Non-human health risks are single digit
            var singlecaseWithHumanHealthRisk = Numbers.Length == 3;
            if (singlecaseWithHumanHealthRisk)
            {
                var sex = (Sex)Numbers[1];
                var ageGroup = Numbers[2];
                MalesAges0To4 = ageGroup == 1 && sex == Sex.Male ? 1 : 0;
                MalesAgedOver4 = ageGroup == 2 && sex == Sex.Male ? 1 : 0;
                FemalesAges0To4 = ageGroup == 1 && sex == Sex.Female ? 1 : 0;
                FemalesAgedOver4 = ageGroup == 2 && sex == Sex.Female ? 1 : 0;
            }

            var hasMultipleCases = Numbers.Length == 5;
            if (hasMultipleCases)
            {
                MalesAges0To4 = Numbers[1];
                MalesAgedOver4 = Numbers[2];
                FemalesAges0To4 = Numbers[3];
                FemalesAgedOver4 = Numbers[4];
            }
        }
    }
}

