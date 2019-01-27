/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Domain.Management.DataCollectors.Training;
using FluentValidation.Results;
using Machine.Specifications;

namespace Domain.Specs.Management.for_data_collectors.when_beginning_training
{
    [Subject("BeginTraining")]
    public class and_validating_a_command_with_a_missing_data_collector_id
    {
        static BeginTraining cmd;
        static BeginTrainingInputValidator validator;
        static ValidationResult validation_results;

        Establish context = () =>
        {
            validator = new BeginTrainingInputValidator();

            cmd = given.a_command_builder.get_invalid_command((cmd) => cmd.DataCollectorId = null);
        };

        Because of = () => { validation_results = validator.Validate(cmd); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();
        It should_have_a_single_validation_error = () => validation_results.ShouldHaveInvalidCountOf(1);
        It should_identify_the_data_collector_id_as_the_problem = () => validation_results.ShouldHaveInvalidProperty(nameof(cmd.DataCollectorId));
    }
}