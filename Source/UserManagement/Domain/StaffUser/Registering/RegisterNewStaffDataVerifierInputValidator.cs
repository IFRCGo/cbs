using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{

    public class RegisterNewStaffDataVerifierInputValidator 
        : NewStaffRegistrationInputValidator<RegisterNewStaffDataVerifier,Domain.StaffUser.Roles.DataVerifier>
    {
    }
}