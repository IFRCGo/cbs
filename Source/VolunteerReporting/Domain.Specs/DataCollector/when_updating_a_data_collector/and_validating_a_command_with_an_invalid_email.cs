/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

//using Machine.Specifications;
//using FluentValidation.Results;
//using System.Collections.Generic;
//using Domain.DataCollectors.Update;

//namespace Domain.Specs.DataCollectors.when_updating_a_data_collector
//{
//    [Subject(typeof(UpdateDataCollectorValidator))]
//    public class and_validating_a_command_with_an_invalid_email
//    {
//        static UpdateDataCollector cmd;
//        static UpdateDataCollectorValidator validator;
//        static ValidationResult validation_results;

//        Establish context = () => 
//        {
//            validator = new UpdateDataCollectorValidator();

//            cmd = given.a_command_builder.get_invalid_command(c => c.Email = "invalid");
//        };

//        Because of = () => { validation_results = validator.Validate(cmd); };

//        It should_be_invalid = () => validation_results.ShouldBeInvalid();
//        It should_have_one_validation_error = () => validation_results.ShouldHaveInvalidCountOf(1);
//        It should_identify_the_email_as_the_problem = () => validation_results.ShouldHaveInvalidProperty(nameof(cmd.Email));
//    }
//}