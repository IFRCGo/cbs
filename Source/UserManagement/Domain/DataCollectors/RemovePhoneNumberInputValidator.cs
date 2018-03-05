/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.DataCollectors
{
    public class RemovePhoneNumberInputValidator : CommandInputValidator<RemovePhoneNumber>
    {
        public RemovePhoneNumberInputValidator()
        {            
            RuleFor(c => c.PhoneNumber)
                .NotEmpty();
            RuleFor(c => c.DataCollectorId)
                .NotEmpty();
        }
    }
}
