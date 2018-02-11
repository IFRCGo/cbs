/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

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
            RuleFor(_ => _.DataOwnerId)
                .NotEmpty()
                .WithMessage("Data owner id is mandatory");
            RuleFor(_ => _.NationalSocietyId)
                .NotEmpty()
                .WithMessage("National society id is mandatory");
            //RuleFor(_ => _.SurveillanceContex)
            //    .NotEmpty()
            //    .WithMessage("Surveillance contex is mandatory");
        }
    }
}