using Concepts.DataCollectors;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollectors
{
    public class ChangeVillageValidator : CommandInputValidatorFor<ChangeVillage>
    {
        public ChangeVillageValidator()
        {
            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("Data Collector Id must be set")
                .SetValidator(new DataCollectorIdValidator());
            RuleFor(_ => _.Village)
                .NotEmpty().WithMessage("Village is required");
        }
    }
}