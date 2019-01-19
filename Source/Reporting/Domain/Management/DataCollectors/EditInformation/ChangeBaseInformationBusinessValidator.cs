/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Management.DataCollectors.EditInformation
{
    public class ChangeBaseInformationBusinessValidator : CommandBusinessValidatorFor<ChangeBaseInformation>
    {
        public ChangeBaseInformationBusinessValidator(
            MustExist beAnActualDataCollector,
            MustBeAllowedToChangeDisplayName beAllowedToChangeDisplayName)
        {
            RuleFor(_ => _.DataCollectorId)
                .Must(_ => beAnActualDataCollector(_))
                .WithMessage(_ => $"Data Collector with id {_.DataCollectorId.Value} is not registered");

            ModelRule()
                .Must(_ => beAllowedToChangeDisplayName(_.DataCollectorId, _.DisplayName))
                .WithMessage(_ => $"Datacollector display name {_.DisplayName} is already taken, choose another");
        }
    }
}