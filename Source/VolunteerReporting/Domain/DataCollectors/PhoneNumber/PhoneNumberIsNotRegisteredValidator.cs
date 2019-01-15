/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using FluentValidation;

namespace Domain.DataCollectors.PhoneNumber
{
    public class PhoneNumberIsNotRegisteredValidator : AbstractValidator<string>
    {
        readonly IPhoneNumberRules _rules;
        public PhoneNumberIsNotRegisteredValidator(IPhoneNumberRules rules)
        {
            _rules = rules;

            RuleFor(number => number)
                .Must(NotBeARegisteredNumber).WithMessage(number => $"Phone number {number} is already registered");
        }


        bool NotBeARegisteredNumber(string number)
        {
            return !_rules.PhoneNumberIsRegistered(number);
        }

    }
}