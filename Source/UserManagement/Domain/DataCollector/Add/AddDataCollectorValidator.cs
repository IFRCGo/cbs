/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.DataCollector.Add
{
    public class AddDataCollectorValidator : CommandInputValidator<AddDataCollector>
    {
        public AddDataCollectorValidator()
        {
            // TODO: Question: Should we have inputvalidation for DataCollectorId?
            // Should Guid be provided in frontend or in the receiving controller?
            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("DataCollectorId must be set")
                .NotEqual(Guid.Empty).WithMessage($"DataCollectorId cannot be equal to {Guid.Empty}");

            RuleFor(_ => _.FullName)
                .NotEmpty()
                .WithMessage("Full name is not correct - Has to be defined");

            RuleFor(_ => _.DisplayName)
                .NotEmpty()
                .WithMessage("Display name is not correct - Has to be defined");

            RuleFor(_ => _.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Must provide a valid email address");



            
        }
    }
}