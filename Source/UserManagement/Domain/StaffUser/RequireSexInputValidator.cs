using FluentValidation;
using System;

namespace Domain.StaffUser
{
    public class RequireSexInputValidator : AbstractValidator<IRequireSex>
    {
        public RequireSexInputValidator()
        {
            RuleFor(ei => ei.Sex)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Sex is required")
                .IsInEnum().WithMessage("Sex is invalid");
                
        }
    }
}