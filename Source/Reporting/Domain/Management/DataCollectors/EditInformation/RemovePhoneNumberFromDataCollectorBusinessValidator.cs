/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Management.DataCollectors.EditInformation
{
    public class RemovePhoneNumberFromDataCollectorBusinessValidator : CommandBusinessValidatorFor<RemovePhoneNumberFromDataCollector>
    {
        public RemovePhoneNumberFromDataCollectorBusinessValidator(MustExist beAnActualDataCollector, PhoneNumberShouldBeRegistered beARegisteredNumber)
        {
            RuleFor(_ => _.DataCollectorId)
                .Must(_ => beAnActualDataCollector(_))
                .WithMessage(_ => $"Data Collector with id {_.DataCollectorId.Value} is not registered");

            RuleFor(_ => _.PhoneNumber)
                .Must(_ => beARegisteredNumber(_)).WithMessage(number => $"Phone number {number} is not registered");
        }
    }
}