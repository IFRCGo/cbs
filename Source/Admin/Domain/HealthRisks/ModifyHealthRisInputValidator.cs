/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.HealthRisks
{
    public class ModifyHealthRisInputValidator : CommandInputValidatorFor<ModifyHealthRisk>
    {
        public ModifyHealthRisInputValidator()
        {
            RuleFor(_ => _.Id)
                .NotEmpty().WithMessage("Health risk id is required");
            RuleFor(_ => _.Name)
                .NotEmpty().WithMessage("Health risk name is required");
            RuleFor(_ => _.ReadableId)
                .NotEmpty().WithMessage("Health risk readable id is required");

            // RuleFor(_ => _.KeyMessage)
            //     .NotEmpty().WithMessage("Health risk key message is required");
            RuleFor(_ => _.CaseDefinition)
                .NotEmpty().WithMessage("Health risk case definition is required");
        }
    }
}