// /*---------------------------------------------------------------------------------------------
//  *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
//  *  Licensed under the MIT License. See LICENSE in the project root for license information.
//  *--------------------------------------------------------------------------------------------*/

// using Domain.DataCollectors.Registration;
// using FluentValidation.Results;
// using Machine.Specifications;

// namespace Domain.Specs.DataCollectors.when_updating_a_data_collector
// {
//     [Subject("Update")]
//     public class and_validating_a_command_with_a_missing_gps_location
//     {
//         static RegisterDataCollector cmd;
//         static RegisterDataCollectorValidator validator;
//         static ValidationResult validation_results;

//         Establish context = () => 
//         {
//             validator = new RegisterDataCollectorValidator();

//             cmd = given.a_command_builder.get_invalid_command((cmd) => cmd.GpsLocation = null);
//         };

//         Because of = () => { validation_results = validator.Validate(cmd); };

//         It should_be_invalid = () => validation_results.ShouldBeInvalid();
//         It should_identify_the_first_name_as_the_problem = () => validation_results.ShouldHaveInvalidProperty(nameof(cmd.GpsLocation));
//     }
// }