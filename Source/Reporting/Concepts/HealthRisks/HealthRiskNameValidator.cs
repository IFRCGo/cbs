/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Validation;
using FluentValidation;

namespace Concepts.HealthRisks
{
    public class HealthRiskNameValidator : AbstractValidator<HealthRiskName>
    {
        public HealthRiskNameValidator()
        {
            RuleFor(_ => _)
                .NotEqual(HealthRiskName.NotSet).WithMessage($"HealthRisk Name must not be '{HealthRiskName.NotSet.Value.ToString()}'");
        }
    }
}