// /*---------------------------------------------------------------------------------------------
//  *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
//  *  Licensed under the MIT License. See LICENSE in the project root for license information.
//  *--------------------------------------------------------------------------------------------*/

using FluentValidation;

namespace Domain
{
    public class CreateProjectValidator : AbstractValidator<CreateProject>
    {
        public CreateProjectValidator()
        {
            RuleFor(_ => _.Name)
                .NotEmpty()
                .WithMessage("Name is mandatory");
        }
    }
}