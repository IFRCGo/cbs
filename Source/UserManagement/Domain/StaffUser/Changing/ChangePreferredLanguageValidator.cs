using Dolittle.Commands.Validation;
using Domain.StaffUser.Roles;
using FluentValidation;

namespace Domain.StaffUser.Changing
{
    public class ChangeUserPreferredLanguageValidator : CommandInputValidatorFor<ChangePreferredLanguage>
    {
        public ChangeUserPreferredLanguageValidator()
        {
            RuleFor(bi => bi.StaffUserId)
                .NotEmpty().WithMessage("An Id for the Staff User is required.");

            RuleFor(_ => _.Role)
                .Must(role => role.HasPreferredLanguage()).WithMessage("This kind of Staffuser does not have preferred language");

            RuleFor(_ => _.PreferredLanguage)
                .IsInEnum().WithMessage("Preferred language is required and must be valid");
        }
    }
}