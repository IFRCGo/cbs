/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Validation;
using FluentValidation;

namespace Concepts.HealthRisks
{
    public class HealthRiskReadableIdValidator : AbstractValidator<HealthRiskReadableId>
    {
        public HealthRiskReadableIdValidator()
        {
            RuleFor(_ => _.Value)
                .NotEqual(HealthRiskReadableId.NotSet).WithMessage($"HealthRisk Readable Id must not be '{HealthRiskReadableId.NotSet.Value.ToString()}'");
        }
    }
}