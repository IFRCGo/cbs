using FluentValidation;

namespace Domain.StaffUser
{
    public class RequireNationalSocietyInputValidator : AbstractValidator<IRequireNationalSociety>
    {
        public RequireNationalSocietyInputValidator()
        {
            RuleFor(_ => _.NationalSociety)
                .NotEmpty().WithMessage("National Society is required");
        }
    }
}