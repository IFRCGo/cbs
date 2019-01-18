/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Domain.Management.DataCollectors.EditInformation;
using FluentValidation.Results;
using Machine.Specifications;

namespace Domain.Specs.Management.DataCollectors.when_removing_a_phone_number
{
    [Subject(typeof(RemovePhoneNumberFromDataCollectorValidator))]
    public class and_validating_a_command_with_a_missing_phone_number
    {
        static ValidationResult validation_results;
        static RemovePhoneNumberFromDataCollectorValidator validator;
        static RemovePhoneNumberFromDataCollector cmd;

        Establish context = () =>
        {
            validator = new RemovePhoneNumberFromDataCollectorValidator();
            cmd = new RemovePhoneNumberFromDataCollector
            {
                DataCollectorId = Guid.NewGuid(),
                PhoneNumber = string.Empty
            };
        };

        Because of = () => { validation_results = validator.Validate(cmd); };
        It should_be_invalid = () => validation_results.ShouldBeInvalid();

        It should_identify_the_phone_number_as_the_error = () =>
            validation_results.ShouldHaveInvalidProperty(nameof(cmd.PhoneNumber));
    }
}