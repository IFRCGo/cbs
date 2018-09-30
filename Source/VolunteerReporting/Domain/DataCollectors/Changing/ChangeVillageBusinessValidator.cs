using Concepts.DataCollector;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollectors.Changing
{
    public class ChangeVillageBusinessValidator : CommandBusinessValidatorFor<ChangeVillage>
    {
        readonly IDataCollectorRules _dataCollectorRules;
        public ChangeVillageBusinessValidator(IDataCollectorRules dataCollectorRules)
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