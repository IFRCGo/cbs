using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollector.Changing
{
    public class ChangeVillageValidator : CommandInputValidatorFor<ChangeVillage>
    {
        public ChangeVillageValidator()
        {
            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("Datacollector ID is required");
            RuleFor(_ => _.Village)
                .NotEmpty().WithMessage("Village ID is required");

        }
    }
}