/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Validation;
using FluentValidation;

namespace Concepts.DataCollectors
{
    public class RegionValidator : InputValidator<Region>
    {
        public RegionValidator()
        {
            RuleFor(_ => _)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Region is required")
                .NotEqual(Region.NotSet).WithMessage($"Region must not be '{Region.NotSet.Value.ToString()}'");
        }
    }
}