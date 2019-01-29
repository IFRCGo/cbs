/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Validation;
using FluentValidation;

namespace Concepts.Projects
{
    public class ProjectIdValidator : AbstractValidator<ProjectId>
    {
        public ProjectIdValidator()
        {
            RuleFor(_ => _)
                .NotEqual(ProjectId.NotSet).WithMessage($"Project Id must not be '{ProjectId.NotSet.Value.ToString()}'");
        }
    }
}