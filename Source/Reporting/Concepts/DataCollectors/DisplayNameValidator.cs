/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Validation;
using FluentValidation;

namespace Concepts.DataCollectors
{
    public class DisplayNameValidator : InputValidator<DisplayName>
    {
        public DisplayNameValidator()
        {
            RuleFor(_ => _)
                .NotEqual(DisplayName.NotSet).WithMessage($"DisplayName must not be '{DisplayName.NotSet.Value.ToString()}'");
        }
    }
}