using Concepts.DataCollector;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollector.PhoneNumber
{
    public class RemovePhoneNumberFromDataCollectorBusinessValidator : CommandBusinessValidatorFor<AddPhoneNumberToDataCollector>
    {
        readonly IDataCollectorRules _dataCollectorRules;
        readonly IPhoneNumberRules _phoneNumberRules;

        public RemovePhoneNumberFromDataCollectorBusinessValidator(IDataCollectorRules dataCollectorRules, IPhoneNumberRules phoneNumberRules)
        {
            _dataCollectorRules = dataCollectorRules;
            _phoneNumberRules = phoneNumberRules;

            RuleFor(_ => _.DataCollectorId)
                .Must(BeRegistered).WithMessage(_ => $"Data Collector with id {_.DataCollectorId.Value} is not registered");
            RuleFor(_ => _.PhoneNumber)
                .SetValidator(new PhoneNumberIsRegisteredValidator(_phoneNumberRules));
        }

        bool BeRegistered(DataCollectorId id)
        {
            return _dataCollectorRules.DataCollectorIsRegistered(id);
        }
    }
}