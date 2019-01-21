/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.DataCollectors;
using FluentValidation;

namespace Domain.Management.DataCollectors.EditInformation
{
    public class AddPhoneNumberToDataCollectorInputValidator : AbstractValidator<AddPhoneNumberToDataCollector>
    {
        public AddPhoneNumberToDataCollectorInputValidator()
        {
            RuleFor(_ => _.DataCollectorId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("DataCollector Id is required")
                .SetValidator(new DataCollectorIdValidator());

            RuleFor(_ => _.PhoneNumber)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("PhoneNumber is required")
                .SetValidator(new PhoneNumberValidator());

        }
    }
}