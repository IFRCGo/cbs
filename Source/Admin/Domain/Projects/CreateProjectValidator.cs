/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Projects
{
    public class CreateProjectValidator : CommandInputValidatorFor<CreateProject>
    {
        public CreateProjectValidator(ProjectNameUnique projectNameUnique)
        {
            RuleFor(_ => _.Name)
                .NotEmpty()
                .WithMessage("Name is mandatory");
            RuleFor(_ => _)
                .Must(p => projectNameUnique(p.Name))
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