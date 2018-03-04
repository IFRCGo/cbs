using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewStaffDataVerifierBusinessRulesValidator 
        : NewStaffRegistrationBusinessRulesValidator<RegisterNewStaffDataVerifier, Domain.StaffUser.Roles.DataVerifier>
    {
        public RegisterNewStaffDataVerifierBusinessRulesValidator(StaffUserIsRegistered isRegistered) : base(isRegistered)
        {
        }
    }
}