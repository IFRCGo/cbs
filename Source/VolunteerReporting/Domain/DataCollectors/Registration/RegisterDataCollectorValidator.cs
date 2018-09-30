/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Linq;
using Concepts;
using Concepts.DataCollector;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollectors.Registration
{
    public class RegisterDataCollectorValidator : CommandInputValidatorFor<RegisterDataCollector>
    {
        public RegisterDataCollectorValidator()
        {
            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("Data Collector Id must be set")
                .SetValidator(new DataCollectorIdValidator());

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
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Location must be provided")
                .Must(l => l.IsValid()).WithMessage(
                    "Location is invalid. Latitude must be in the range -90 to 90 and longitude in the range -180 to 180")
                .Must(l => !l.Equals(Location.NotSet)).WithMessage("Location cannot be -1, -1");
                
                
            RuleFor(_ => _.PreferredLanguage)
                .IsInEnum().WithMessage("Preferred Language is required and must be valid");

            RuleFor(_ => _.YearOfBirth)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Year of birth is required")
                .InclusiveBetween(1900, DateTime.UtcNow.Year).WithMessage("Year of birth must be greater than 1900 and less than " + DateTimeOffset.UtcNow.Year);

            RuleFor(_ => _.PhoneNumbers)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("At least one Phone Number is required")
                .Must(c => c.Any(s => !string.IsNullOrWhiteSpace(s))).WithMessage("All phonenumbers must be valid");

            RuleFor(_ => _.District)
                .NotEmpty()
                .WithMessage("District is not correct - Has to be defined");

            RuleFor(_ => _.Region)
                .NotEmpty()
                .WithMessage("Region is not correct - Has to be defined");
        }
    }
}