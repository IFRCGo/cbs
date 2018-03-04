using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewDataOwnerBusinessRulesValidator 
                    : NewStaffRegistrationBusinessRulesValidator<RegisterNewDataOwner, Domain.StaffUser.Roles.DataOwner>
    {
        public RegisterNewDataOwnerBusinessRulesValidator(StaffUserIsRegistered isRegistered) : base(isRegistered)
        {
        }
    }
}