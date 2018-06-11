using Concepts;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollector.Changing
{
    public class ChangeLocationValidator : CommandInputValidatorFor<ChangeLocation>
    {
        public ChangeLocationValidator()
        {
            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("Data Collector Id must be set")
                .SetValidator(new DataCollectorIdValidator());

            RuleFor(_ => _.Location)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Location must be provided")
                .Must(l => l.IsValid()).WithMessage(
                    "Location is invalid. Latitude must be in the range -90 to 90 and longitude in the range -180 to 180")
                .Must(l => !l.Equals(Location.NotSet)).WithMessage("Location cannot be -1, -1");

        }   
    }
}