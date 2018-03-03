using System;
using FluentValidation;
using System.Linq;
using System.Collections.Generic;

namespace Domain.StaffUser
{

    public class StaffRoleValidator : AbstractValidator<StaffRole>
    {
        public StaffRoleValidator()
        {
            RuleFor(_ => _)
                .SetValidator(new RoleValidator());

            RuleFor(ei => ei.NationalSociety)
                .NotEmpty().WithMessage("A National Society is required");
        }
    }
}