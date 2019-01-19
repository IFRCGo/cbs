/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.DataCollectors;
using FluentValidation;

namespace Domain.Management.DataCollectors.EditInformation
{
    public class RemovePhoneNumberFromDataCollectorInputValidator : AbstractValidator<RemovePhoneNumberFromDataCollector>
    {
        public RemovePhoneNumberFromDataCollectorInputValidator()
        {
            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("Data Collector Id must be set")
                .SetValidator(new DataCollectorIdValidator());

            RuleFor(_ => _.PhoneNumber)
                .NotEmpty().WithMessage("Phone Numbe is required");
        }
    }
}