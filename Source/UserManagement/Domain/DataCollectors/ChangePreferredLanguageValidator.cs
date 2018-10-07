using Concepts.DataCollectors;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollectors
{
    public class ChangePreferredLanguageValidator : CommandInputValidatorFor<ChangePreferredLanguage>
    {
        public ChangePreferredLanguageValidator()
        {
            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("Data Collector Id must be set")
                .SetValidator(new DataCollectorIdValidator());

            RuleFor(_ => _.PreferredLanguage)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .IsInEnum().WithMessage("Preferred Language must be valid");
        }
    }
}