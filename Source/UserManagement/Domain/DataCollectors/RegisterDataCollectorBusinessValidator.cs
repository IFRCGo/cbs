using System.Collections.Generic;
using Concepts.DataCollectors;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollectors
{
    public class RegisterDataCollectorBusinessValidator : CommandBusinessValidatorFor<RegisterDataCollector>
    {
        readonly IPhoneNumberRules _phoneNumberRules;

        public RegisterDataCollectorBusinessValidator(DataCollectorExists dataCollectorExists, IsDataCollectorDisplayNameTaken displayNameNotBeTaken, IPhoneNumberRules phoneNumberRules)
        {
            _phoneNumberRules = phoneNumberRules;
            RuleFor(_ => _.DataCollectorId)
                .Must(dataCollector => !dataCollectorExists(dataCollector))
                .WithMessage(_ => $"Data Collector with id {_.DataCollectorId.Value} is not registered");

            RuleFor(_ => _.PhoneNumbers)
                .SetCollectionValidator(new PhoneNumberIsNotRegisteredValidator(_phoneNumberRules));

            RuleFor(_ => _.DisplayName)
                .Must(_ => !displayNameNotBeTaken(_)).WithMessage(_ => $"Datacollector display name {_.DisplayName} is already taken, choose another");
        }
    }
}