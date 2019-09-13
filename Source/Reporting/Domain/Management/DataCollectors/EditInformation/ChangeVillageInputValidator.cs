/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.DataCollectors;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Management.DataCollectors.EditInformation
{
    public class ChangeVillageInputValidator : CommandInputValidatorFor<ChangeVillage>
    {
        public ChangeVillageInputValidator(VillageMustBeReal villageMustBeReal)
        {
            RuleFor(_ => _.DataCollectorId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("DataCollector Id is required")
                .SetValidator(new DataCollectorIdValidator());
            RuleFor(_ => _.Village)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Village is required")
                .Must(_ => villageMustBeReal(_)).WithMessage(_ => $"{_.Village} is not a real location");
        }
    }
}