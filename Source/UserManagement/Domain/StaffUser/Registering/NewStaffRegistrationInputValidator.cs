using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public abstract class NewStaffRegistrationInputValidator<TCommand,TRole> : CommandInputValidator<TCommand> 
        where TCommand : NewStaffRegistration<TRole>
        where TRole : Domain.StaffUser.Roles.StaffRole
    {
        protected NewStaffRegistrationInputValidator()
        {
            RuleFor(_ => _.Role)
                .NotNull().WithMessage("Role is required")
                .SetValidator(new HaveUserInfoValidator());
        }
    }
}