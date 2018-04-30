using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.StaffUser.Changing
{
    public class ChangeAdminInformationValidator : CommandInputValidatorFor<ChangeAdminInformation>
    {
        public ChangeAdminInformationValidator()
        {
            RuleFor(bi => bi.StaffUserId)
                .NotEmpty().WithMessage("An Id for the Staff User is required.");

            RuleFor(bi => bi.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("A valid email address is required")
                .EmailAddress().WithMessage("A valid email address is required.");

            RuleFor(bi => bi.FullName)
                .NotEmpty().WithMessage("Fullname is required.");

            RuleFor(bi => bi.DisplayName)
                .NotEmpty().WithMessage("Display name is required.");
        }
    }
}