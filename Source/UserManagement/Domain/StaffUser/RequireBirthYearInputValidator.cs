using FluentValidation;
using System;

namespace Domain.StaffUser
{
    public class RequireBirthYearInputValidator : AbstractValidator<IRequireBirthYear>
    {
        public RequireBirthYearInputValidator()
        {
            RuleFor(ei => ei.BirthYear)
                .InclusiveBetween(1900,DateTime.UtcNow.Year).WithMessage("Birth Year is invalid");
                
        }
    }
}