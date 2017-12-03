/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using FluentValidation;
using Read.ProjectFeatures;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class SetProjectHealthRiskThresholdValidator : AbstractValidator<SetProjectHealthRiskThreshold>
    {
        private readonly IProjects _projects;

        public SetProjectHealthRiskThresholdValidator(IProjects projects)
        {
            _projects = projects;
            RuleFor(v => v.Threshold).GreaterThan(0).WithMessage("The threshold can not be zero or negative");
            RuleFor(v => v).Must(HealthRiskBelongsToProject);
        }

        private bool HealthRiskBelongsToProject(SetProjectHealthRiskThreshold arg)
        {
            var project = _projects.GetById(arg.ProjectId);
            return (project?.HealthRisks?.Any(v => v.HealthRiskId == arg.HealthRiskId) == true);
        }
    }
}
