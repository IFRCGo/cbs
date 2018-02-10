/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using FluentValidation;

namespace Domain
{
    public class AddProjectHealthRiskValidator : AbstractValidator<AddProjectHealthRisk>
    {
        public AddProjectHealthRiskValidator(IProjectHealthRiskRules projectHealthRiskRules)
        {

            RuleFor(_ => _.ProjectId)
                .Must(projectHealthRiskRules.IsWithinNumberOfHealthRisksLimit)
                .WithMessage("Project does not allow health risks to be added");
            RuleFor(_ => _)
                .Must(p => projectHealthRiskRules.IsHealthRiskUniqueWithinProject(p.HealthRiskId, p.ProjectId))
                .WithMessage("Project does not allow health risks to be added");
            RuleFor(_ => _)
                .Must(p => projectHealthRiskRules.IsHealthRiskExisting(p.HealthRiskId))
                .WithMessage("Project does not allow health risks to be added");
        }
    }
}