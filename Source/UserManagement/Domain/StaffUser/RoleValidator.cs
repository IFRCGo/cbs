using System;
using FluentValidation;
using System.Linq;
using System.Collections.Generic;

namespace Domain.StaffUser
{
    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(ei => ei.YearOfBirth)
                .InclusiveBetween(1900,DateTime.UtcNow.Year).WithMessage("Year of birth is invalid").When(yob => yob != null);
            
            RuleFor(ei => ei.Sex)
                .IsInEnum().WithMessage("Sex is invalid").When(s => s!= null);
            
            RuleFor(ei => ei.PreferredLanguage)
                .IsInEnum().WithMessage("Preferred Language is required");

            RuleFor(ei => ei.NationalSociety)
                .NotEmpty().WithMessage("A National Society is required");
            
            RuleFor(ei => ei.PhoneNumbers)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("A Phone Number is required")
                .Must((IEnumerable<string> c) => c.Any(s => !string.IsNullOrWhiteSpace(s))).WithMessage("A Phone Number is required");
        }
    }
}