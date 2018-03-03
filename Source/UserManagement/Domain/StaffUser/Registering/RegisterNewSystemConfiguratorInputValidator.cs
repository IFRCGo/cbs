using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewSystemConfiguratorInputValidator 
                    : NewExtendedRegistrationInputValidator<RegisterNewSystemConfigurator, SystemConfigurator>
    {
        public RegisterNewSystemConfiguratorInputValidator()
        {
            RuleFor(_ => (_ as IAmAssignedToNationalSocieties))
                .NotNull()
                .SetValidator(new AssignedToNationalSocietiesInputValidator());
        }
    }
}