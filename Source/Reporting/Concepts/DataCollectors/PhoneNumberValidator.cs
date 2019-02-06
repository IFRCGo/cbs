/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Validation;
using FluentValidation;

namespace Concepts.DataCollectors
{
    public class PhoneNumberValidator : InputValidator<PhoneNumber>
    {
        public PhoneNumberValidator()
        {
            RuleFor(_ => _)
                .NotEqual(PhoneNumber.NotSet).WithMessage($"PhoneNumber must not be '{PhoneNumber.NotSet.Value.ToString()}'")
                .Must(notContainSpaces).WithMessage("Phone number is not valid - it contains spaces");
        }
        bool notContainSpaces(PhoneNumber _) => !((string)_).Contains(" ");
    }
}