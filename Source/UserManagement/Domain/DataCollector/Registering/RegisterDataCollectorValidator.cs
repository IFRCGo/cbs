/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Linq;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollector.Registering
{
    public class RegisterDataCollectorValidator : CommandInputValidatorFor<RegisterDataCollector>
    {
        public RegisterDataCollectorValidator()
        {

            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("Data Collector Id must be set");

            RuleFor(_ => _.FullName)
                .NotEmpty()
                .WithMessage("Full Name is not correct - Has to be defined");

            RuleFor(_ => _.DisplayName)
                .NotEmpty()
                .WithMessage("Display Name is not correct - Has to be defined");

            //TODO: Add later
            //RuleFor(_ => _.Email)
            //    .Cascade(CascadeMode.StopOnFirstFailure)
            //    .EmailAddress().WithMessage("Email address must be valid");

            RuleFor(_ => _.Sex)
                .IsInEnum().WithMessage("Sex is invalid").When(s => s != null);

            RuleFor(_ => _.GpsLocation)
                .NotNull().WithMessage("Location must be provided")
                .Must(l => l.IsValid()).WithMessage("Location is invalid. Latitude must be in the range -90 to 90 and longitude in the range -180 to 180");
                
            RuleFor(_ => _.PreferredLanguage)
                .IsInEnum().WithMessage("Preferred Language is required and must be valid");

            RuleFor(_ => _.YearOfBirth)
                .InclusiveBetween(1900, DateTime.UtcNow.Year).WithMessage("Year of birth is required").When(y => y != null);

            RuleFor(_ => _.PhoneNumbers)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("At least one Phone Number is required")
                .Must(c => c.Any(s => !string.IsNullOrWhiteSpace(s))).WithMessage("All phonenumbers must be valid");

        }
    }
}