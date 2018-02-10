/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using FluentValidation;

namespace Domain
{
    public class UpdateProjectHealthRiskThresholdValidator : AbstractValidator<UpdateProjectHealthRiskThreshold>
    {
        public UpdateProjectHealthRiskThresholdValidator()
        {
            RuleFor(v => v.Threshold).GreaterThan(0).WithMessage("The threshold can not be zero or negative");
        }
    }
}
