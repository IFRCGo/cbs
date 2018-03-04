using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewStaffDataConsumerBusinessRulesValidator : NewRegistrationBusinessRulesValidator<RegisterNewStaffDataConsumer>
    {
        public RegisterNewStaffDataConsumerBusinessRulesValidator(StaffUserIsRegistered isRegistered) : base(isRegistered)
        {
        }
    }
}