/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class SetProjectHealthRiskThresholdValidator : AbstractValidator<SetProjectHealthRiskThreshold>
    {
        public SetProjectHealthRiskThresholdValidator()
        {
            RuleFor(v => v.Threshold).GreaterThan(0).WithMessage("The threshold can not be zero or negative");
            RuleFor(v => v).Must(HealthRiskBelongsToProject);
        }

        private bool HealthRiskBelongsToProject(SetProjectHealthRiskThreshold arg)
        {
            // TODO: Use read model to verify the health risk is registered on the project
            return true;
        }
    }
}
