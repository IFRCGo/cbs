// /*---------------------------------------------------------------------------------------------
//  *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
//  *  Licensed under the MIT License. See LICENSE in the project root for license information.
//  *--------------------------------------------------------------------------------------------*/

// using Domain.DataCollectors.Registration;
// using Machine.Specifications;
// using FluentValidation.Results;

//  namespace Domain.Specs.DataCollectors.when_updating_a_data_collector
//  {
//      [Subject("Update")]
//      public class and_validating_a_valid_command
//      {
//          static RegisterDataCollector cmd;
//          static RegisterDataCollectorValidator validator;
//          static ValidationResult validation_results;

//          Establish context = () => 
//          {
//              validator = new RegisterDataCollectorValidator();

//              cmd = given.a_command_builder.get_valid_command();
//          };

//          Because of = () => { validation_results = validator.Validate(cmd); };

//          It should_be_valid = () => validation_results.ShouldBeValid();
//      }
//  }