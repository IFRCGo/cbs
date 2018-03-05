/*---------------------------------------------------------------------------------------------
*  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
using Machine.Specifications;
using FluentValidation.Results;
using System.Collections.Generic;
using Domain.DataCollector.Update;

namespace Domain.Specs.DataCollector.when_updating_a_data_collector
{
    [Subject(typeof(UpdateDataCollectorValidator))]
    public class and_validating_a_command_with_a_missing_display_name
    {
        static UpdateDataCollector cmd;
        static UpdateDataCollectorValidator validator;
        static ValidationResult validation_results;

        Establish context = () => 
        {
            validator = new UpdateDataCollectorValidator();

            cmd = given.a_command_builder.get_invalid_command((cmd) => cmd.DisplayName = null);
        };

        Because of = () => { validation_results = validator.Validate(cmd); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();
        It should_identify_the_display_name_as_the_problem = () => validation_results.ShouldHaveInvalidProperty(nameof(cmd.DisplayName));
    }

 }