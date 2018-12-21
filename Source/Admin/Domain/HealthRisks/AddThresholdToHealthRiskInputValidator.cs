/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.HealthRisks
{
    public class AddThresholdToHealthRiskInputValidator : CommandInputValidatorFor<AddThresholdToHealthRisk>
    {
        public AddThresholdToHealthRiskInputValidator()
        {
            RuleFor(_ => _.HealthRiskId)
                .NotEmpty()
                .WithMessage("Health risk id is required");

            RuleFor(_ => _.Threshold)
                .NotEmpty()
                .WithMessage("Threshold is required");

        }
    }
}