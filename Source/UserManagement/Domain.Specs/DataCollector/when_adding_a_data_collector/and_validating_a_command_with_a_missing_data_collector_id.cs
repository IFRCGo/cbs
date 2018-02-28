using System;
using Domain.DataCollector.Add;
using FluentValidation.Results;
using Machine.Specifications;

namespace Domain.Specs.DataCollector.when_adding_a_data_collector
{
    [Subject(typeof(AddDataCollectorValidator))]
    public class and_validating_a_command_with_a_missing_data_collector_id
    {
        static AddDataCollector cmd;
        static AddDataCollectorValidator validator;
        static ValidationResult validation_results;

        Establish context = () => 
        {
            validator = new AddDataCollectorValidator();

            cmd = given.a_command_builder.get_invalid_command((cmd) => cmd.DataCollectorId = Guid.Empty);
        };

        Because of = () => { validation_results = validator.Validate(cmd); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();
        It should_identify_the_data_collector_id_as_the_problem = () => validation_results.ShouldHaveInvalidProperty(nameof(cmd.DataCollectorId));
    }
}