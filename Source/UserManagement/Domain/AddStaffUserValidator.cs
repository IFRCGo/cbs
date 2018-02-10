/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using FluentValidation;

namespace Domain
{
    public class AddStaffUserValidator : AbstractValidator<AddStaffUser>
    {
        public AddStaffUserValidator()
        {
            RuleFor(_ => _.FirstName)
                .NotEmpty()
                .WithMessage("First name is not correct - Has to be defined");

            RuleFor(_ => _.LastName)
                .NotEmpty()
                .WithMessage("Last name is not correct - Has to be defined");

            RuleFor(_ => _.Age)
                .GreaterThan(0)
                .WithMessage("Age is not correct - Has to be greater than 0");

            RuleFor(_ => _.Sex)
                .IsInEnum()
                .WithMessage("Sex is not correct - Has to be a valid value");

            RuleFor(_ => _.NationalSociety)
                .NotEmpty()
                .WithMessage("National Society is not correct - Has to be a IRC Society");

            RuleFor(_ => _.PreferredLanguage)
                .IsInEnum()
                .WithMessage("Preferred language is not correct - Has to be a supported languge");

            //TODO: Validate MobilePhoneNumber based on localization
            RuleFor(_ => _.MobilePhoneNumber)
                .NotEmpty()
                //.Matches(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")
                .WithMessage("Mobile phone number is not correct - Has to be of correct form");

            RuleFor(_ => _.Email)
                .EmailAddress()
                .NotEmpty()
                .WithMessage("Email is invalid - Has to be of valid format");
        }
    }
}
