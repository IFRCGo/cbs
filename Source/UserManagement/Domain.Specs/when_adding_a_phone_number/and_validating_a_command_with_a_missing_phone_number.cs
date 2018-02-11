using System;
using System.Collections.Generic;
using doLittle.Validation;
using Domain.DataCollectors;
using Domain.Specs;
using Machine.Specifications;

namespace Domain.Specs.when_adding_a_phone_number
{
    [Subject(typeof(AddPhoneNumber))]
    public class and_validating_a_command_with_a_missing_phone_number
    {
        static AddPhoneNumber cmd;
        static AddPhoneNumberInputValidator validator;
        static IEnumerable<ValidationResult> validation_results;

        Establish the_command = () =>
        {
            validator = new AddPhoneNumberInputValidator();

            cmd = new AddPhoneNumber
            {
                DataCollectorId = Guid.NewGuid(),
                PhoneNumber = string.Empty
            };
        };

        Because of = () => { validation_results = validator.ValidateFor(cmd); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();

        It should_have_one_validation_result = () => validation_results.ShouldHaveInvalidCountOf(1);

        It should_identify_the_phone_number_as_the_problem =
            () => validation_results.ShouldHaveInvalidProperty(nameof(cmd.PhoneNumber));
    }
}