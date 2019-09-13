/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Machine.Specifications;
using FluentValidation.Results;
using Domain.Management.DataCollectors.Registration;

namespace Domain.Specs.Management.for_data_collectors.when_registering_a_data_collector
{
     [Subject("Registration")]
     public class and_validating_a_valid_command
     {
         static RegisterDataCollector cmd;
         static RegisterDataCollectorInputValidator validator;
         static ValidationResult validation_results;
        static Domain.Management.DataCollectors.RegionMustBeReal regionMustBeReal;
        static Domain.Management.DataCollectors.DistrictMustBeReal districtMustBeReal;

         Establish context = () => 
         {
             validator = new RegisterDataCollectorInputValidator(regionMustBeReal, districtMustBeReal);

             cmd = given.a_command_builder.get_valid_command();
         };

         Because of = () => { validation_results = validator.Validate(cmd); };

         It should_be_valid = () => validation_results.ShouldBeValid();
     }
}