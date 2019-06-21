using Dolittle.Commands.Validation;

namespace Domain.HealthRisk
{
    public class CreateHealthRiskInputValidator : CommandInputValidatorFor<CreateHealthRisk>
    {
        public CreateHealthRiskInputValidator()
        {
            RuleFor(cmd => cmd.HealthRiskName)
                .NotEmpty()
                .WithMessage("Health risk must have a name");

            RuleFor(cmd => cmd.HealthRiskId)
                .NotEmpty()
                .WithMessage("Health risk must have an id");
        }
        
        
    }
}
