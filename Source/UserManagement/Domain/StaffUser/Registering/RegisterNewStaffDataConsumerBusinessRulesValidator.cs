using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewStaffDataConsumerBusinessRulesValidator 
        : NewStaffRegistrationBusinessRulesValidator<RegisterNewStaffDataConsumer, Domain.StaffUser.Roles.DataConsumer>
    {
        public RegisterNewStaffDataConsumerBusinessRulesValidator(StaffUserIsRegistered isRegistered) : base(isRegistered)
        {
        }
    }
}