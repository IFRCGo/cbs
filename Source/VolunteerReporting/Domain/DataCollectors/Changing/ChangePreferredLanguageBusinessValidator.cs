/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.DataCollector;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollectors.Changing
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