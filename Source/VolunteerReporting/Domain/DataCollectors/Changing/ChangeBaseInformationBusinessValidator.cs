/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.DataCollector;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollectors.Changing
{
    public class ChangeBaseInformationBusinessValidator : CommandBusinessValidatorFor<ChangeBaseInformation>
    {
        readonly IDataCollectorRules _dataCollectorRules;

        public ChangeBaseInformationBusinessValidator(IDataCollectorRules dataCollectorRules)
        {
            _dataCollectorRules = dataCollectorRules;

            RuleFor(_ => _.DataCollectorId)
                .Must(BeRegistered).WithMessage(_ => $"Data Collector with id {_.DataCollectorId.Value} is not registered");

            RuleFor(command =>  command) // New display name must not be taken
                .Must(_dataCollectorRules.DataCollectorCanChangeDisplayName)
                .WithMessage(_ => $"Datacollector display name {_.DisplayName} is already taken, choose another");
        }

        bool BeRegistered(DataCollectorId id)
        {
            return _dataCollectorRules.DataCollectorIsRegistered(id);
        }
    }
}