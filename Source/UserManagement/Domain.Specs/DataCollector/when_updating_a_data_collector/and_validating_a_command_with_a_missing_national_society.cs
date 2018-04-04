using System;
using Domain.DataCollector.Registering;
using FluentValidation.Results;
using Machine.Specifications;

namespace Domain.Specs.DataCollector.when_updating_a_data_collector
{
    [Subject("Update")]
    public class and_validating_a_command_with_a_missing_national_society
    {
        static RegisterDataCollector cmd;
        static RegisterDataCollectorValidator validator;
        static ValidationResult validation_results;

        Establish context = () => 
        {
            validator = new RegisterDataCollectorValidator();

            cmd = given.a_command_builder.get_invalid_command((cmd) => cmd.NationalSociety = Guid.Empty);
        };

        Because of = () => { validation_results = validator.Validate(cmd); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();
        It should_identify_the_national_society_as_the_problem = () => validation_results.ShouldHaveInvalidProperty(nameof(cmd.NationalSociety));
    }
}