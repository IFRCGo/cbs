/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain
{
    public class AddDataCollectorValidator : CommandInputValidator<AddDataCollector>
    {
        public AddDataCollectorValidator()
        {
            RuleFor(_ => _.FirstName)
                .NotEmpty()
                .WithMessage("First name is not correct - Has to be defined");

            RuleFor(_ => _.LastName)
                .NotEmpty()
                .WithMessage("Last name is not correct - Has to be defined");


            RuleFor(_ => _.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Must provide a valid email address");
            //TODO: rest of the rules
        }
    }
}