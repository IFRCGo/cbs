using Domain.Management.DataCollectors.Registration;
using FluentValidation.Results;
using Machine.Specifications;

namespace Domain.Specs.Management.DataCollectors.when_registering_a_data_collector
{
    [Subject("Registration")]
    public class and_validating_a_command_with_an_invalid_region
    {
        static RegisterDataCollector cmd;
        static RegisterDataCollectorInputValidator validator;
        static ValidationResult validation_results;

        Establish context = () =>
        {
            validator = new RegisterDataCollectorInputValidator();

            cmd = given.a_command_builder.get_invalid_command((cmd) => cmd.Region = null);
        };

        Because of = () => { validation_results = validator.Validate(cmd); };
        It should_be_invalid = () => validation_results.ShouldBeInvalid();
        It should_identify_the_region_as_the_problem = () => validation_results.ShouldHaveInvalidProperty(nameof(cmd.Region));
    }
}