using Domain.DataCollector.Update;
using FluentValidation.Results;
using Machine.Specifications;

namespace Domain.Specs.DataCollector.when_updating_a_data_collector
{
    [Subject(typeof(UpdateDataCollectorValidator))]
    public class and_validating_a_command_with_invalid_added_phone_numbers
    {
        static UpdateDataCollector cmd;
        static UpdateDataCollectorValidator validator;
        static ValidationResult validation_results;

        Establish context = () => 
        {
            validator = new UpdateDataCollectorValidator();

            cmd = given.a_command_builder.get_invalid_command(
                (cmd) => cmd.PhoneNumbersAdded = new string[1] {string.Empty});
        };

        Because of = () => { validation_results = validator.Validate(cmd); };
        It should_be_invalid = () => validation_results.ShouldBeInvalid();
        It should_identify_the_first_name_as_the_problem = () => validation_results.ShouldHaveInvalidProperty(nameof(cmd.PhoneNumbersAdded));
    }
}