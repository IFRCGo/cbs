using Concepts.DataCollector;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollector.Changing
{
    public class ChangePreferredLanguageBusinessValidator : CommandBusinessValidatorFor<ChangePreferredLanguage>
    {
        readonly IDataCollectorRules _dataCollectorRules;

        public ChangePreferredLanguageBusinessValidator(IDataCollectorRules dataCollectorRules)
        {
            _dataCollectorRules = dataCollectorRules;

            RuleFor(_ => _.DataCollectorId)
                .Must(BeRegistered).WithMessage(_ => $"Data Collector with id {_.DataCollectorId.Value} is not registered");
        }

        bool BeRegistered(DataCollectorId id)
        {
            return _dataCollectorRules.DataCollectorIsRegistered(id);
        }
    }
}