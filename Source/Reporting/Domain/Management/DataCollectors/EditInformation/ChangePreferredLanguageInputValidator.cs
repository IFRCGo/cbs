/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.DataCollectors;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Management.DataCollectors.EditInformation
{
    public class ChangePreferredLanguageInputValidator : CommandInputValidatorFor<ChangePreferredLanguage>
    {
        public ChangePreferredLanguageInputValidator()
        {
            RuleFor(_ => _.DataCollectorId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("DataCollector Id is required")
                .SetValidator(new DataCollectorIdValidator());

            RuleFor(_ => _.PreferredLanguage)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .IsInEnum().WithMessage("Preferred Language must be valid");
        }
    }
}