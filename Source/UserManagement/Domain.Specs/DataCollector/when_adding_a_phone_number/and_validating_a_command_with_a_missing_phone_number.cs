using System;
using Domain.DataCollectors.PhoneNumber;
using FluentValidation.Results;
using Machine.Specifications;

namespace Domain.Specs.DataCollector.when_adding_a_phone_number
{
    [Subject(typeof(AddPhoneNumberToDataCollectorValidator))]
    public class and_validating_a_command_with_a_missing_phone_number
    {
        static AddPhoneNumberToDataCollector cmd;
        static AddPhoneNumberToDataCollectorValidator validator;
        static ValidationResult validation_result;

        Establish the_command = () =>
        {
            validator = new AddPhoneNumberToDataCollectorValidator();

            cmd = new AddPhoneNumberToDataCollector
            {
                DataCollectorId = Guid.NewGuid(),
                PhoneNumber = string.Empty
            };
        };

        Because of = () => { validation_result = validator.Validate(cmd); };

        It should_be_invalid = () => validation_result.ShouldBeInvalid();

        It should_have_one_validation_result = () => validation_result.ShouldHaveInvalidCountOf(1);

        It should_identify_the_phone_number_as_the_problem =
            () => validation_result.ShouldHaveInvalidProperty(nameof(cmd.PhoneNumber));
    }
}