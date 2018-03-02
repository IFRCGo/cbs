using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewSystemConfiguratorInputValidator : NewExtendedRegistrationInputValidator<RegisterNewSystemConfigurator>
    {
        public RegisterNewSystemConfiguratorInputValidator()
        {
            RuleFor(_ => (_ as IHaveALocation))
                .NotNull()
                .SetValidator(new HaveALocationValidator());
        }
    }
}