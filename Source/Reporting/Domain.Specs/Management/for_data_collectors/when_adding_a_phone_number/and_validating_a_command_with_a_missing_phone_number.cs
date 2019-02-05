/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Domain.Management.DataCollectors.EditInformation;
using FluentValidation.Results;
using Machine.Specifications;

namespace Domain.Specs.Management.for_data_collectors.when_adding_a_phone_number
{
    [Subject(typeof(AddPhoneNumberToDataCollectorInputValidator))]
    public class and_validating_a_command_with_a_missing_phone_number
    {
        static AddPhoneNumberToDataCollector cmd;
        static AddPhoneNumberToDataCollectorInputValidator validator;
        static ValidationResult validation_result;

        Establish the_command = () =>
        {
            validator = new AddPhoneNumberToDataCollectorInputValidator();

            cmd = new AddPhoneNumberToDataCollector
            {
                DataCollectorId = Guid.NewGuid()
            };
        };

        Because of = () => { validation_result = validator.Validate(cmd); };

        It should_be_invalid = () => validation_result.ShouldBeInvalid();

        It should_have_one_validation_result = () => validation_result.ShouldHaveInvalidCountOf(1);

        It should_identify_the_phone_number_as_the_problem =
            () => validation_result.ShouldHaveInvalidProperty(nameof(cmd.PhoneNumber));
    }
}