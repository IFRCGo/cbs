using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public abstract class NewRegistrationInputValidator<T> : CommandInputValidator<T> where T : NewRegistration
    {
        protected NewRegistrationInputValidator()
        {
            RuleFor(_ => _.UserDetails)
                .NotNull().WithMessage("User Details are required")
                .SetValidator(new BasicInfoValidator());
        }
    }
}