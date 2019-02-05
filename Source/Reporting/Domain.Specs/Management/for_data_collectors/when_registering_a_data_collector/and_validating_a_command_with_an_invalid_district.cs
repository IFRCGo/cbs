/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Domain.Management.DataCollectors.Registration;
using FluentValidation.Results;
using Machine.Specifications;

namespace Domain.Specs.Management.for_data_collectors.when_registering_a_data_collector
{
    [Subject("Registration")]
    public class and_validating_a_command_with_an_invalid_district
    {
        static RegisterDataCollector cmd;
        static RegisterDataCollectorInputValidator validator;
        static ValidationResult validation_results;

        Establish context = () =>
        {
            validator = new RegisterDataCollectorInputValidator();

            cmd = given.a_command_builder.get_invalid_command((cmd) => cmd.District = string.Empty);
        };

        Because of = () => { validation_results = validator.Validate(cmd); };
        It should_be_invalid = () => validation_results.ShouldBeInvalid();
        It should_identify_the_district_as_the_problem = () => validation_results.ShouldHaveInvalidProperty(nameof(cmd.District));
    }
}