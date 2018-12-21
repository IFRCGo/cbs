/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands.Validation;
using Domain.Projects;
using FluentValidation;

namespace Domain.Admin
{
    public class AddDataVerifierValidator : CommandInputValidatorFor<AddDataVerifier>
    {
        public AddDataVerifierValidator(Rules userExist, Projects.Rules isUserNotAVerifier)
        {
            RuleFor(_ => _.ProjectId)
                .NotEmpty()
                .WithMessage("Project must be specified");
            RuleFor(_ => _.UserId)
                .NotEmpty()
                .WithMessage("UserId must be specified");
            RuleFor(_ => _)
                .Must(p => userExist(p.UserId))
                .WithMessage("User is not existing");
            RuleFor(_ => _)
                .Must(p => isUserNotAVerifier(p.ProjectId, p.UserId))
                .WithMessage("User is already a verifier");
        }
    }
}