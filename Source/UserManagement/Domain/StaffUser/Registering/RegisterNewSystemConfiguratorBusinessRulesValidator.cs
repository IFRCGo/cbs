using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewSystemConfiguratorBusinessRulesValidator : NewRegistrationBusinessRulesValidator<RegisterNewSystemConfigurator>
    {
        public RegisterNewSystemConfiguratorBusinessRulesValidator(StaffUserIsRegistered isRegistered) : base(isRegistered)
        {
        }
    }
}