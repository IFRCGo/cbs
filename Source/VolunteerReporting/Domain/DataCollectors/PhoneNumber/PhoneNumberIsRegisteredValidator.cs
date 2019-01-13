/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using FluentValidation;

namespace Domain.DataCollectors.PhoneNumber
{
    public class PhoneNumberIsRegisteredValidator : AbstractValidator<string>
    {
        readonly IPhoneNumberRules _rules;
        public PhoneNumberIsRegisteredValidator(IPhoneNumberRules rules)
        {
            _rules = rules;

            RuleFor(number => number)
                .Must(BeARegisteredNumber).WithMessage(number => $"Phone number {number} is not registered");
        }

        bool BeARegisteredNumber(string number)
        {
            return _rules.PhoneNumberIsRegistered(number);
        }
    }
}