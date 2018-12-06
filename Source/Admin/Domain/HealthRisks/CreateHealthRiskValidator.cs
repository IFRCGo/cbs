/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.HealthRisks
{
    public class CreateHealthRiskValidator : CommandInputValidatorFor<CreateHealthRisk>
    {
        public CreateHealthRiskValidator()
        {
            RuleFor(_ => _.Id)
                .NotEmpty().WithMessage("Health risk id is required");
            RuleFor(_ => _.Name)
                .NotEmpty().WithMessage("Health risk name is required");
            RuleFor(_ => _.CaseDefinition)
                .NotEmpty().WithMessage("Case definition is required");
        }
    }
}