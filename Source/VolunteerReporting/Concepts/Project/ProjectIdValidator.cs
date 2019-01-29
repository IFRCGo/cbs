/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Validation;
using FluentValidation;

namespace Concepts.Project
{
    public class ProjectIdValidator : InputValidator<ProjectId>
    {
        public ProjectIdValidator()
        {
            RuleFor(_ => _.Value)
                .NotEmpty().WithMessage("Project Id cannot be empty");
        }
    }
}