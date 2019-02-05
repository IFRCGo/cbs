/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Management.DataCollectors.EditInformation
{
    public class AddPhoneNumberToDataCollectorBusinessValidator : CommandBusinessValidatorFor<AddPhoneNumberToDataCollector>
    {
        public AddPhoneNumberToDataCollectorBusinessValidator(MustExist beAnActualDataCollector, PhoneNumberShouldNotBeRegistered notBeARegisteredNumber)
        {
            RuleFor(_ => _.DataCollectorId)
                .Must(_ => beAnActualDataCollector(_))
                .WithMessage(_ => $"Data Collector with id {_.DataCollectorId.Value} is not registered");

            RuleFor(_ => _.PhoneNumber)
                .Must(_ => notBeARegisteredNumber(_)).WithMessage(number => $"Phone number {number} is already registered");
        }
    }
}