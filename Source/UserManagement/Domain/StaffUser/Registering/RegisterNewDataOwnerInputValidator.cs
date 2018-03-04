using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewDataOwnerInputValidator : NewStaffRegistrationInputValidator<RegisterNewDataOwner,Domain.StaffUser.Roles.DataOwner>
    {
        public RegisterNewDataOwnerInputValidator()
        {
            RuleFor(_ => (_ as IRequireLocation))
                .NotNull()
                .SetValidator(new RequireLocationValidator());
            RuleFor(_ => _.Position)
                .NotEmpty().WithMessage("Position is required");
            RuleFor(_ => _.DutyStation)
                .NotEmpty().WithMessage("Duty Station is required");   
        }
    }
}