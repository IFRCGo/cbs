/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Domain.DataCollectors.PhoneNumber;
using FluentValidation.Results;
using Machine.Specifications;

namespace Domain.Specs.DataCollectors.when_adding_a_phone_number
{
    [Subject(typeof(AddPhoneNumberToDataCollectorValidator))]
    public class and_validating_a_valid_command
    {
        static AddPhoneNumberToDataCollector cmd;
        static AddPhoneNumberToDataCollectorValidator validator;
        static ValidationResult validation_results;

        Establish context = () => 
        {
            validator = new AddPhoneNumberToDataCollectorValidator();

            cmd = new AddPhoneNumberToDataCollector 
            {
                DataCollectorId = Guid.NewGuid(),
                PhoneNumber = "11223344"
            };
        };

        Because of = () => { validation_results = validator.Validate(cmd); };
        It should_be_invalid = () => validation_results.ShouldBeValid();
    }
}