/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Domain;
using System;
using Machine.Specifications;
using doLittle.Validation;
using System.Linq;
using System.Collections.Generic;
using Concepts;
using Domain.DataCollectors.Commands;
using Domain.DataCollectors.Validators;

namespace Domain.Specs.when_adding_a_data_collector
{
    /*
    [Subject(typeof(AddDataCollectorValidator))]
    public class and_validating_a_valid_command
    {
        static AddDataCollector cmd;
        static AddDataCollectorValidator validator;
        static IEnumerable<ValidationResult> validation_results;

        Establish context = () => 
        {
            validator = new AddDataCollectorValidator();

            cmd = given.a_command_builder.get_valid_command();
        };

        Because of = () => { validation_results = validator.ValidateFor(cmd); };

        It should_be_valid = () => validation_results.ShouldBeValid();
    }
    */
}