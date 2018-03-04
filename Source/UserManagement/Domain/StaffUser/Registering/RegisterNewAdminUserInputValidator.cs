using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{

    public class RegisterNewAdminUserInputValidator : NewStaffRegistrationInputValidator<RegisterNewAdminUser>
    {
    }
}