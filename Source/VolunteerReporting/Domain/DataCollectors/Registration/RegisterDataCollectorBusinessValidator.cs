using System.Collections.Generic;
using Concepts.DataCollector;
using Dolittle.Commands.Validation;
using Domain.DataCollectors.PhoneNumber;
using FluentValidation;

namespace Domain.DataCollectors.Registration
{
    public class RegisterDataCollectorBusinessValidator : CommandBusinessValidatorFor<RegisterDataCollector>
    {
        readonly IDataCollectorRules _dataCollectorRules;
        readonly IPhoneNumberRules _phoneNumberRules;

        public RegisterDataCollectorBusinessValidator(IDataCollectorRules dataCollectorRules, IPhoneNumberRules phoneNumberRules) 
        {
            _dataCollectorRules = dataCollectorRules;
            _phoneNumberRules = phoneNumberRules;

            RuleFor(_ => _.DataCollectorId)
                .Must(NotBeRegistered).WithMessage("Datacollector with same id is already registered");
            
            RuleFor(_ => _.PhoneNumbers)
                .SetCollectionValidator(new PhoneNumberIsNotRegisteredValidator(_phoneNumberRules));

            RuleFor(_ => _.DisplayName)
                .Must(DisplayNameNotTaken).WithMessage(_ => $"Datacollector display name {_.DisplayName} is already taken, choose another");
        }

        bool NotBeRegistered(DataCollectorId id)
        {
            return !_dataCollectorRules.DataCollectorIsRegistered(id);
        }
        bool DisplayNameNotTaken(string displayName) {
            return !_dataCollectorRules.DataCollectorDisplayNameRegistered(displayName);
        }
    }
}