/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using doLittle.FluentValidation.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DataCollectors
{
    public class AddPhoneNumberInputValidator : CommandInputValidator<AddPhoneNumber>
    {
        public AddPhoneNumberInputValidator()
        {
            //TODO: Add validation for valid phone number
            RuleFor(c => c.PhoneNumber)
                .NotEmpty();
            RuleFor(c => c.DataCollectorId)
                .NotEmpty();                
        }
    }
}
