using System;
using System.Collections.Generic;
using System.Linq;
using Domain.DataCollector.Update;
using FluentValidation;

namespace Domain.DataCollector.Update
{
    public class UpdateDataCollectorValidator : AbstractValidator<UpdateDataCollector>
    {
        public UpdateDataCollectorValidator()
        {
            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("Data Collector Id must be set");

            RuleFor(_ => _.FullName)
                .NotEmpty()
                .WithMessage("Full Name is not correct - Has to be defined");

            RuleFor(_ => _.DisplayName)
                .NotEmpty()
                .WithMessage("Display Name is not correct - Has to be defined");

            RuleFor(_ => _.GpsLocation)
                .NotNull().WithMessage("Location must be provided");
            //TODO: UNcomment when merged with Michael's branch.Must(l => l.isValid()).WithMessage("Location is invalid. Latitude must be in the range -90 to 90 and longitude in the range -180 to 180");

            RuleFor(_ => _.NationalSociety)
                .NotEmpty().WithMessage("A National Society is required");

            RuleFor(_ => _.PreferredLanguage)
                .IsInEnum().WithMessage("Preferred Language is required and must be valid");

            When(_ => _.PhoneNumbersAdded != null, () =>
            {
                RuleFor(_ => _.PhoneNumbersAdded)
                    .Must((IEnumerable<string> c) => c.Any(s => !string.IsNullOrWhiteSpace(s))).WithMessage("All phonenumbers must be valid");
            });

            When(_ => _.PhoneNumbersRemoved != null, () =>
            {
                RuleFor(_ => _.PhoneNumbersRemoved)
                    .Must((IEnumerable<string> c) => c.Any(s => !string.IsNullOrWhiteSpace(s))).WithMessage("All phonenumbers must be valid");
            });
        }
    }
}