/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Validation;
using FluentValidation;

namespace Concepts.DataCollectors
{
    public class YearOfBirthValidator : InputValidator<YearOfBirth>
    {
        public YearOfBirthValidator()
        {
            RuleFor(_ => _)
                .NotEqual(YearOfBirth.NotSet).WithMessage($"YearOfBirth must not be '{YearOfBirth.NotSet.Value.ToString()}'")
                .Must(beBetween1900AndNow).WithMessage("Year of birth must be greater or equal than 1900 and less than or equal to " + DateTimeOffset.UtcNow.Year);
        }
        bool beBetween1900AndNow(YearOfBirth _) => _.Value >= 1900 && _.Value <= DateTime.UtcNow.Year;
    }
}