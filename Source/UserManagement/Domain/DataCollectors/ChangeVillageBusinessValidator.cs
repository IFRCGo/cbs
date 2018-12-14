/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollectors
{
    public class ChangeVillageBusinessValidator : CommandBusinessValidatorFor<ChangeVillage>
    {
        public ChangeVillageBusinessValidator(MustExist beAnActualDataCollector)
        {
            RuleFor(_ => _.DataCollectorId)
                .Must(_ => beAnActualDataCollector(_))
                .WithMessage(_ => $"Data Collector with id {_.DataCollectorId.Value} is not registered");
        }
   }
}