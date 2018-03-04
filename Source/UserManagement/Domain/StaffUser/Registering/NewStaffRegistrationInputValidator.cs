using doLittle.FluentValidation.Commands;

namespace Domain.StaffUser.Registering
{
    public abstract class NewStaffRegistrationInputValidator<T> : CommandInputValidator<T> where T : NewStaffRegistration
    {
        protected NewStaffRegistrationInputValidator()
        {
            RuleFor(_ => _)
                .SetValidator(new HaveUserInfoValidator());
        }
    }
}