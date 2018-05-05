
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.HealthRisk
{
    public class ModifyHealthRiskValidator : CommandInputValidatorFor<ModifyHealthRisk>
    {
        public ModifyHealthRiskValidator()
        {
            RuleFor(_ => _.Id)
                .NotEmpty().WithMessage("Health risk id is required");
            RuleFor(_ => _.Name)
                .NotEmpty().WithMessage("Health risk name is required");
            RuleFor(_ => _.ReadableId)
                .NotEmpty().WithMessage("Health risk readable id is required");

            RuleFor(_ => _.KeyMessage)
                .NotEmpty().WithMessage("Health risk key message is required");
            RuleFor(_ => _.CaseDefinition)
                .NotEmpty().WithMessage("Health risk case definition is required");
        }
    }
}