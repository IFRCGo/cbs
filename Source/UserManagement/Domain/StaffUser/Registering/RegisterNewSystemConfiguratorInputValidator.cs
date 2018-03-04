using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewSystemConfiguratorInputValidator 
                    : NewStaffRegistrationInputValidator<RegisterNewSystemConfigurator, Domain.StaffUser.Roles.SystemConfigurator>
    {
    }
}