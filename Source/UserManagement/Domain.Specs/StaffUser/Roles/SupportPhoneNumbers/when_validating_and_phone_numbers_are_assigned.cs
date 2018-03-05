using System;
using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Concepts;
using Moq;
using It = Machine.Specifications.It;

namespace Domain.Specs.StaffUser.Roles.SupportPhoneNumbers
{
    [Subject(typeof(ISupportPhoneNumbers))]
    public class when_validating_and_phone_numbers_are_assigned
    {
        static SupportPhoneNumbersInputValidator validator;
        static ValidationResult validation_results;
        static Mock<ISupportPhoneNumbers> support_phone_numbers;

        Establish context = () =>
        {
            validator = new SupportPhoneNumbersInputValidator();
            support_phone_numbers = new Mock<ISupportPhoneNumbers>();
            support_phone_numbers.SetupGet(m => m.PhoneNumbers).Returns(new []{ "888888" });
        };

        Because of = () => { validation_results = validator.Validate(support_phone_numbers.Object); };

        It should_be_valid = () => validation_results.ShouldBeValid();    
    }
}