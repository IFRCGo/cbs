using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewSystemConfiguratorInputValidator 
                    : NewStaffRegistrationInputValidator<RegisterNewSystemConfigurator, Domain.StaffUser.Roles.SystemConfigurator>
    {
        public RegisterNewSystemConfiguratorInputValidator()
        {
            RuleFor(_ => (_ as IAmAssignedToNationalSocieties))
                .NotNull()
                .SetValidator(new AssignedToNationalSocietiesInputValidator());
        }
    }
}