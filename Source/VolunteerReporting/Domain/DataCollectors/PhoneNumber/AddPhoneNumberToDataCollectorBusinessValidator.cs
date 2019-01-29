/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.DataCollector;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollectors.PhoneNumber
{
    public class AddPhoneNumberToDataCollectorBusinessValidator : CommandBusinessValidatorFor<AddPhoneNumberToDataCollector>
    {
        readonly IDataCollectorRules _dataCollectorRules;
        readonly IPhoneNumberRules _phoneNumberRules;

        public AddPhoneNumberToDataCollectorBusinessValidator(IDataCollectorRules dataCollectorRules, IPhoneNumberRules phoneNumberRules)
        {
            _dataCollectorRules = dataCollectorRules;
            _phoneNumberRules = phoneNumberRules;

            RuleFor(_ => _.DataCollectorId)
                .Must(BeRegistered).WithMessage(_ => $"Data Collector with id {_.DataCollectorId.Value} is not registered");

            RuleFor(_ => _.PhoneNumber)
                .SetValidator(new PhoneNumberIsNotRegisteredValidator(_phoneNumberRules));
        }
        bool BeRegistered(DataCollectorId id)
        {
            return _dataCollectorRules.DataCollectorIsRegistered(id);
        }
    }
}