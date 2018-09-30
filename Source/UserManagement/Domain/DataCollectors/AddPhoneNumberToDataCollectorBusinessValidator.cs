using Concepts.DataCollectors;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollectors
{
    public class AddPhoneNumberToDataCollectorBusinessValidator : CommandBusinessValidatorFor<AddPhoneNumberToDataCollector>
    {
        readonly IPhoneNumberRules _phoneNumberRules;

        public AddPhoneNumberToDataCollectorBusinessValidator(DataCollectorExists dataCollectorExists, IPhoneNumberRules phoneNumberRules)
        {
            _phoneNumberRules = phoneNumberRules;

            RuleFor(_ => _.DataCollectorId)
                .Must((dataCollector) => dataCollectorExists(dataCollector))
                .WithMessage(_ => $"Data Collector with id {_.DataCollectorId.Value} is not registered");

            RuleFor(_ => _.PhoneNumber)
                .SetValidator(new PhoneNumberIsNotRegisteredValidator(_phoneNumberRules));
        }
    }
}