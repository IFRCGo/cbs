using System;
using Dolittle.Commands.Validation;
using Domain.StaffUser.Roles;
using FluentValidation;

namespace Domain.StaffUser.Changing
{
    public class ChangeNationalSocietyValidator : CommandInputValidatorFor<ChangeNationalSociety>
    {
        public ChangeNationalSocietyValidator()
        {
            RuleFor(bi => bi.StaffUserId)
                .NotEmpty().WithMessage("An Id for the Staff User is required.");

            RuleFor(_ => _.Role)
                .Must(role => role.HasNationalSociety()).WithMessage("This kind of Staffuser does not have a National Society");

            RuleFor(_ => _.NationalSociety)
                .NotEmpty().WithMessage("National Society is required")
                .NotEqual(Guid.Empty).WithMessage("National Society cannot be empty");

        }
    }
}