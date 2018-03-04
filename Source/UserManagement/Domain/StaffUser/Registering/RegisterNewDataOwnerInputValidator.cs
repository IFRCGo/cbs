using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{

    public class RegisterNewDataOwnerInputValidator : NewExtendedRegistrationInputValidator<RegisterNewDataOwner,DataOwner>
    {
        public RegisterNewDataOwnerInputValidator()
        {
            RuleFor(_ => (_ as IHaveALocation))
                .NotNull()
                .SetValidator(new HaveALocationValidator());
            RuleFor(_ => _.Position)
                .NotEmpty().WithMessage("Position is required");
            RuleFor(_ => _.DutyStation)
                .NotEmpty().WithMessage("Duty Station is required");   
        }
    }
}