using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewAdminUserBusinessRulesValidator : NewStaffRegistrationBusinessRulesValidator<RegisterNewAdminUser>
    {
        public RegisterNewAdminUserBusinessRulesValidator(StaffUserIsRegistered isRegistered) : base(isRegistered)
        {
        }
    }
}