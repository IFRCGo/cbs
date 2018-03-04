using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{

    public class RegisterNewStaffDataVerifierInputValidator : NewExtendedRegistrationInputValidator<RegisterNewDataOwner,DataOwner>
    {
        public RegisterNewStaffDataVerifierInputValidator()
        {
            RuleFor(_ => (_ as IHaveALocation))
                .NotNull()
                .SetValidator(new HaveALocationValidator());
            //these are normally optional on role, but not for data verifiers
            //the StaffRoleValidator validates the correctness of the values if provided, 
            //so we only have to enforce that they are provided here
            RuleFor(_ => _.Role.Sex)
                .NotNull().WithMessage("Sex is required");
            RuleFor(_ => _.Role.YearOfBirth)
                .NotNull().WithMessage("Year of Birth is required"); 
            
        }
    }
}