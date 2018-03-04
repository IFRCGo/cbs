using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewDataOwnerInputValidator : NewStaffRegistrationInputValidator<RegisterNewDataOwner,Domain.StaffUser.Roles.DataOwner>
    {
    }
}