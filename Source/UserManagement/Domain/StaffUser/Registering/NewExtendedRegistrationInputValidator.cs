using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public abstract class NewExtendedRegistrationInputValidator<TCommand,TRole> : CommandInputValidator<TCommand> 
        where TCommand : NewExtendedRegistration<TRole> 
        where TRole : Role
    {
        protected NewExtendedRegistrationInputValidator()
        {
            RuleFor(_ => _.Role)
                .NotNull().WithMessage("Extended Details are required")
                .SetValidator(new RoleValidator());
        }
    }
}