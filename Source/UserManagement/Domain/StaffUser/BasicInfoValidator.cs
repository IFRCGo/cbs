using FluentValidation;

namespace Domain.StaffUser
{
    public class BasicInfoValidator : AbstractValidator<BasicInfo>
    {
        public BasicInfoValidator()
        {
            ValidatorOptions.CascadeMode = CascadeMode.Continue;

            RuleFor(bi => bi.StaffUserId)
                .NotEmpty().WithMessage("An Id for the Staff User is required.");

            RuleFor(bi => bi.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("A valid email address is required")
                .EmailAddress().WithMessage("A valid email address is required.");

            RuleFor(bi => bi.FullName)
                .NotEmpty().WithMessage("Fullname is required.");
        }
    }
}