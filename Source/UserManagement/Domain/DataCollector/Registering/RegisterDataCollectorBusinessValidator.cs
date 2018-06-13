using System.Collections.Generic;
using Concepts.DataCollector;
using Dolittle.Commands.Validation;
using Domain.DataCollector.PhoneNumber;
using FluentValidation;

namespace Domain.DataCollector.Registering
{
    public class RegisterDataCollectorBusinessValidator : CommandBusinessValidatorFor<RegisterDataCollector>
    {
        IDataCollectorRegistrationRules _registrationRules;
        IPhoneNumberRules _phoneNumberRules;
        public RegisterDataCollectorBusinessValidator(IDataCollectorRegistrationRules registrationRules, IPhoneNumberRules phoneNumberRules) 
        {
            _registrationRules = registrationRules;
            _phoneNumberRules = phoneNumberRules;
            RuleFor(_ => _.DataCollectorId)
                .Must(NotBeRegistered).WithMessage("Datacollector with same id is already registered");
            
            RuleFor(_ => _.PhoneNumbers)
                .SetCollectionValidator(new PhoneNumberIsNotRegisteredValidator(_phoneNumberRules));
        }

        bool NotBeRegistered(DataCollectorId id)
        {
            return !_registrationRules.DataCollectorIsRegistered(id);
        }
    }
}