/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using FluentValidation;

namespace Domain
{
    public class CreateProjectValidator : AbstractValidator<CreateProject>
    {
        public CreateProjectValidator(IProjectRules projectRules)
        {
            RuleFor(_ => _.Name)
                .NotEmpty()
                .WithMessage("Name is mandatory");
            RuleFor(_ => _)
                .Must(p => projectRules.IsProjectNameUnique(p.Name))
                .WithMessage("Project name is already in use");
            RuleFor(_ => _.DataOwnerId)
                .NotEmpty()
                .WithMessage("Data owner id is mandatory");
            RuleFor(_ => _.NationalSocietyId)
                .NotEmpty()
                .WithMessage("National society id is mandatory");
            RuleFor(_ => _.SurveillanceContext)
                .NotEmpty()
                .WithMessage("Surveillance context is mandatory");
        }
    }
}