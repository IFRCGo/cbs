using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public abstract class NewExtendedRegistrationInputValidator<T> : CommandInputValidator<T> where T : NewExtendedRegistration
    {
        protected NewExtendedRegistrationInputValidator()
        {
            RuleFor(_ => _.Role)
                .NotNull().WithMessage("Extended Details are required")
                .SetValidator(new RoleValidator());
        }
    }
}