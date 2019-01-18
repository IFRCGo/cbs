/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Validation;
using FluentValidation;

namespace Concepts.HealthRisks
{
    public class HealthRiskIdValidator : InputValidator<HealthRiskId>
    {
        public HealthRiskIdValidator()
        {
            RuleFor(_ => _.Value)
                .NotEmpty().WithMessage("HealthRisk Id cannot be empty");
        }
    }
}