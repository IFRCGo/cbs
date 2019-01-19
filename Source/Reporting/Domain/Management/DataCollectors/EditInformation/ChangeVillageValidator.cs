/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.DataCollectors;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Management.DataCollectors.EditInformation
{
    public class ChangeVillageValidator : CommandInputValidatorFor<ChangeVillage>
    {
        public ChangeVillageValidator()
        {
            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("Data Collector Id must be set")
                .SetValidator(new DataCollectorIdValidator());
            RuleFor(_ => _.Village)
                .NotEmpty().WithMessage("Village is required");
        }
    }
}