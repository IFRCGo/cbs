/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Domain.Management.DataCollectors.EditInformation;
using Machine.Specifications;
using FluentValidation.Results;
using Concepts.DataCollectors;

namespace Domain.Specs.Management.for_data_collectors.when_adding_a_phone_number
{
    
    [Subject(typeof(AddPhoneNumberToDataCollectorInputValidator))]
    public class and_validating_a_command_with_a_missing_data_collector_id { 

        static AddPhoneNumberToDataCollector cmd;
        static AddPhoneNumberToDataCollectorInputValidator validator;
        static ValidationResult validation_result;

        Establish the_command = () =>
        {
            validator = new AddPhoneNumberToDataCollectorInputValidator();

            cmd = new AddPhoneNumberToDataCollector
            {
                PhoneNumber = "123"
            };
        };

        Because of = () => validation_result = validator.Validate(cmd);

        It should_be_invalid = () => validation_result.ShouldBeInvalid();

        It should_have_one_validation_result = () => validation_result.ShouldHaveInvalidCountOf(1);

        It should_identify_the_data_collector_id_as_the_problem =
            () => validation_result.ShouldHaveInvalidProperty(nameof(cmd.DataCollectorId));
            
    }
}