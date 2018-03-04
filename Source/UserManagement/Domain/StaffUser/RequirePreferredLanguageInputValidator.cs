using System;
using FluentValidation;
using System.Linq;
using System.Collections.Generic;

namespace Domain.StaffUser
{

    public class RequirePreferredLanguageInputValidator : AbstractValidator<IRequirePreferredLanguage>
    {
        public RequirePreferredLanguageInputValidator()
        {
            RuleFor(_ => _.PreferredLanguage)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Preferred Language is required")
                .IsInEnum().WithMessage("Preferred Language is invalid");
        }
    }
}