/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Validation;
using FluentValidation;

namespace Concepts.DataCollectors
{
    public class FullNameValidator : InputValidator<FullName>
    {
        public FullNameValidator()
        {
            RuleFor(_ => _)
                .NotEqual(FullName.NotSet).WithMessage($"DisplayName must not be '{FullName.NotSet.Value.ToString()}'");
        }
    }
}