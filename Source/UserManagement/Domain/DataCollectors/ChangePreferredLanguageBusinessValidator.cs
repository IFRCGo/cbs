using Concepts.DataCollectors;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollectors
{
    public class ChangePreferredLanguageBusinessValidator : CommandBusinessValidatorFor<ChangePreferredLanguage>
    {
        public ChangePreferredLanguageBusinessValidator(DataCollectorExists dataCollectorExists)
        {
            RuleFor(_ => _.DataCollectorId)
                .Must(dataCollector => dataCollectorExists(dataCollector))
                .WithMessage(_ => $"Data Collector with id {_.DataCollectorId.Value} is not registered");
        }
    }
}