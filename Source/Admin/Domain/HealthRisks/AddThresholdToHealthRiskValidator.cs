using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.HealthRisks
{
    public class AddThresholdToHealthRiskValidator : CommandInputValidatorFor<AddThresholdToHealthRisk>
    {
        public AddThresholdToHealthRiskValidator()
        {
            RuleFor(_ => _.HealthRiskId)
                .NotEmpty()
                .WithMessage("Health risk id is required");

            RuleFor(_ => _.Threshold)
                .NotEmpty()
                .WithMessage("Threshold is required");

        }
    }
}