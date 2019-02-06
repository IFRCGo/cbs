/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Domain.Management.DataCollectors.EditInformation;
using FluentValidation.Results;
using Machine.Specifications;

namespace Domain.Specs.Management.for_data_collectors.when_removing_a_phone_number
{
    [Subject(typeof(RemovePhoneNumberFromDataCollectorInputValidator))]
    public class and_validating_a_command_with_a_missing_data_collector_id
    {
        static RemovePhoneNumberFromDataCollectorInputValidator validator;
        static ValidationResult validation_results;

        static RemovePhoneNumberFromDataCollector cmd;

        private Establish context = () =>
        {
            validator = new RemovePhoneNumberFromDataCollectorInputValidator();
            cmd = new RemovePhoneNumberFromDataCollector
            {
                PhoneNumber = "11223344"
            };
        };

        Because of = () => { validation_results = validator.Validate(cmd); };
        It should_be_invalid = () => validation_results.ShouldBeInvalid();

        It should_identitfy_the_data_collector_id_as_the_error = () =>
            validation_results.ShouldHaveInvalidProperty(nameof(cmd.DataCollectorId));

    }
}