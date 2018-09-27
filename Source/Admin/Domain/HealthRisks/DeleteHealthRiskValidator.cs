using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.HealthRisks
{
    public class DeleteHealthRiskValidator : CommandInputValidatorFor<DeleteHealthRisk>
    {
        public DeleteHealthRiskValidator()
        {
            RuleFor(_ => _.HealthRiskId)
                .NotEmpty().WithMessage("Healthrisk id is required");
        }
    }
}