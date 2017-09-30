using FluentValidation;

namespace Domain
{
    public class CreateProjectValidator : AbstractValidator<CreateProject>
    {
        public CreateProjectValidator()
        {
            RuleFor(_ => _.Name)
                .NotEmpty()
                .WithMessage("Name is mandatory");
        }
    }
}