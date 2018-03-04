using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{

    public class RegisterNewStaffDataVerifierInputValidator : NewExtendedRegistrationInputValidator<RegisterNewStaffDataVerifier,StaffDataVerifier>
    {
        public RegisterNewStaffDataVerifierInputValidator()
        {
            RuleFor(_ => (_ as IRequireLocation))
                .NotNull()
                .SetValidator(new RequireLocationValidator());
            //these are normally optional on role, but not for data verifiers
            //the StaffRoleValidator validates the correctness of the values if provided, 
            //so we only have to enforce that they are provided here
            RuleFor(_ => _.Role.Sex)
                .NotNull().WithMessage("Sex is required");
            RuleFor(_ => _.Role.YearOfBirth)
                .NotNull().WithMessage("Birth Year is required"); 
            
        }
    }
}