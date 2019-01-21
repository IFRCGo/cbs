/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Validation;
using FluentValidation;

namespace Concepts.DataCollectors
{
    public class DistrictValidator : InputValidator<District>
    {
        public DistrictValidator()
        {
            RuleFor(_ => _)
                .NotEqual(District.NotSet).WithMessage($"District must not be '{District.NotSet.Value.ToString()}'");
        }
    }
}