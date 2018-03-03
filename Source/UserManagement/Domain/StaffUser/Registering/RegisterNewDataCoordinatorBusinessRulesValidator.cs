using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{

    public class RegisterNewDataCoordinatorBusinessRulesValidator : NewRegistrationBusinessRulesValidator<RegisterNewDataCoordinator>
    {
        public RegisterNewDataCoordinatorBusinessRulesValidator(StaffUserIsRegistered isRegistered) : base(isRegistered)
        {
        }
    }    
}