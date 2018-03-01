using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewAdminUserInputValidator : CommandInputValidator<RegisterNewAdminUser>
    {
        public RegisterNewAdminUserInputValidator()
        {
            RuleFor(_ => _.UserDetails)
                .NotNull().WithMessage("User Details are required")
                .SetValidator(new BasicInfoValidator());
        }
    }
}