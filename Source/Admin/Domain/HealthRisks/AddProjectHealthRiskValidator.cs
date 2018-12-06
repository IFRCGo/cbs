/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.HealthRisks
{
    public class AddProjectHealthRiskValidator : CommandInputValidatorFor<AddProjectHealthRisk>
    {
        public AddProjectHealthRiskValidator(IsWithinNumberOfHealthRisksLimit isWithinNumberOfHealthRisksLimit, IsHealthRiskUniqueWithinProject isHealthRiskUniqueWithinProject, IsHealthRiskExisting isHealthRiskExisting)
        {
            RuleFor(_ => _.ProjectId)
                .Must(_ => isWithinNumberOfHealthRisksLimit(_))
                .WithMessage("Project does not allow health risks to be added");
            RuleFor(_ => _)
                .Must(p => isHealthRiskUniqueWithinProject(p.HealthRiskId, p.ProjectId))
                .WithMessage("Project does not allow health risks to be added");
            RuleFor(_ => _)
                .Must(p => isHealthRiskExisting(p.HealthRiskId))
                .WithMessage("Project does not allow health risks to be added");
        }
    }
}