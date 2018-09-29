using Dolittle.Validation;
using FluentValidation;

namespace Concepts.Project
{
    public class ProjectIdValidator : InputValidator<ProjectId>
    {
        public ProjectIdValidator()
        {
            RuleFor(_ => _.Value)
                .NotEmpty().WithMessage("Project Id cannot be empty");
        }
    }
}