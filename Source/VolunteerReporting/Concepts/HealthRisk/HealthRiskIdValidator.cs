using Dolittle.Validation;
using FluentValidation;
namespace Concepts.HealthRisk
{
    public class HealthRiskIdValidator : InputValidator<HealthRiskId>
    {
        public HealthRiskIdValidator()
        {
            RuleFor(_ => _.Value)
                .NotEmpty().WithMessage("HealthRisk Id cannot be empty");
        }
    }
}