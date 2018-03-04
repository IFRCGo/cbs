using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewAdminUserBusinessRulesValidator 
                    : NewStaffRegistrationBusinessRulesValidator<RegisterNewAdminUser, Domain.StaffUser.Roles.Admin>
    {
        public RegisterNewAdminUserBusinessRulesValidator(StaffUserIsRegistered isRegistered) : base(isRegistered)
        {
        }
    }
}