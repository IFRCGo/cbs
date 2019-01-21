/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Validation;
using FluentValidation;

namespace Concepts.HealthRisks
{
    public class HealthRiskIdValidator : AbstractValidator<HealthRiskId>
    {
        public HealthRiskIdValidator()
        {
            RuleFor(_ => _)
                .NotEqual(HealthRiskId.NotSet).WithMessage($"HealthRisk Id must not be '{HealthRiskId.NotSet.Value.ToString()}'");
        }
    }
}