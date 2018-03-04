using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{

    public class RegisterNewStaffDataVerifierBusinessRulesValidator : NewRegistrationBusinessRulesValidator<RegisterNewStaffDataVerifier>
    {
        public RegisterNewStaffDataVerifierBusinessRulesValidator(StaffUserIsRegistered isRegistered) : base(isRegistered)
        {
        }
    }
}