/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using doLittle.FluentValidation.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DataCollectors
{
    public class AddPhoneNumberBusinessValidator : CommandBusinessValidator<AddPhoneNumber>
    {
        //TODO: Add validation that checks if phone number already exist. Should not add same number twice
        //QUESTION: How should the domain get access to existing data? Domain should not know about read model, but how else can we do this?
    }
}
