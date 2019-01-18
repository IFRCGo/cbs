/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Management.DataCollectors.Registration
{
    public class RegisterDataCollectorBusinessValidator : CommandBusinessValidatorFor<RegisterDataCollector>
    {
        // TODO
        //public RegisterDataCollectorBusinessValidator(
        //    CantExist notExistAlready,
        //    DisplayNameMustBeUnique haveUniqueDisplayName,
        //    PhoneNumberShouldNotBeRegistered notBeARegisteredNumber)
        //{
        //    RuleFor(_ => _.DataCollectorId)
        //        .Must(_ => notExistAlready(_))
        //        .WithMessage(_ => $"Data Collector with id {_.DataCollectorId.Value} is not registered");

        //    RuleForEach(_ => _.PhoneNumbers)
        //        .Must(_ => notBeARegisteredNumber(_)).WithMessage(number => $"Phone number {number} is already registered");

        //    RuleFor(_ => _.DisplayName)
        //        .Must(_ => haveUniqueDisplayName(_)).WithMessage(_ => $"Datacollector display name {_.DisplayName} is already taken, choose another");
        //}
    }
}