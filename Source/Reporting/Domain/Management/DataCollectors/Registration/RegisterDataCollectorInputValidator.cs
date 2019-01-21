/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Linq;
using Concepts.DataCollectors;
using Concepts.DataVerifiers;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Management.DataCollectors.Registration
{
    public class RegisterDataCollectorInputValidator : CommandInputValidatorFor<RegisterDataCollector>
    {
        public RegisterDataCollectorInputValidator()
        {
            RuleFor(_ => _.DataCollectorId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("DataCollector Id is required")
                .SetValidator(new DataCollectorIdValidator());

            RuleFor(_ => _.FullName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("FullName is required")
                .SetValidator(new FullNameValidator());

            RuleFor(_ => _.DisplayName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("DisplayName is required")
                .SetValidator(new DisplayNameValidator());

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
                .NotNull().WithMessage("YearOfBirth is required")
                .SetValidator(new YearOfBirthValidator());


            RuleFor(_ => _.PhoneNumbers)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("At least one Phone Number is required");

            RuleForEach(_ => _.PhoneNumbers)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("PhoneNumbers cannot contain a PhoneNumber that is null")
                .SetValidator(new PhoneNumberValidator());

            RuleFor(_ => _.District)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("District is required")
                .SetValidator(new DistrictValidator());

            RuleFor(_ => _.Region)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Region is required")
                .SetValidator(new RegionValidator());

            RuleFor(_ => _.DataVerifierId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("DataVerifier Id is required")
                .SetValidator(new DataVerifierIdValidator());
        }
    }
}