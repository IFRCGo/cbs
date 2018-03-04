using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewDataOwnerBusinessRulesValidator : NewRegistrationBusinessRulesValidator<RegisterNewDataOwner>
    {
        public RegisterNewDataOwnerBusinessRulesValidator(StaffUserIsRegistered isRegistered) : base(isRegistered)
        {
        }
    }
}