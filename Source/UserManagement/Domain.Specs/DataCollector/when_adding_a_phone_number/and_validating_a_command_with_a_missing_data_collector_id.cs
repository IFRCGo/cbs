
using Domain.DataCollector.PhoneNumber;
using Machine.Specifications;
using FluentValidation.Results;

namespace Domain.Specs.DataCollector.when_adding_a_phone_number
{
    
    [Subject(typeof(AddPhoneNumberToDataCollectorValidator))]
    public class and_validating_a_command_with_a_missing_data_collector_id { 

        static AddPhoneNumberToDataCollector cmd;
        static AddPhoneNumberToDataCollectorValidator validator;
        static ValidationResult validation_result;

        Establish the_command = () =>
        {
            validator = new AddPhoneNumberToDataCollectorValidator();

            cmd = new AddPhoneNumberToDataCollector
            {
                PhoneNumber = "123"
            };
        };

        Because of = () => { validation_result = validator.Validate(cmd); };

        It should_be_invalid = () => validation_result.ShouldBeInvalid();

        It should_have_one_validation_result = () => validation_result.ShouldHaveInvalidCountOf(1);

        It should_identify_the_data_collector_id_as_the_problem =
            () => validation_result.ShouldHaveInvalidProperty(nameof(cmd.DataCollectorId));
            
    }
}