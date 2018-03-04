using System;
using System.Collections.Generic;
using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Concepts;
using Moq;
using It = Machine.Specifications.It;

namespace Domain.Specs.StaffUser.RequirePhoneNumbers
{

     [Subject(typeof(IRequirePhoneNumbers))]
    public class when_validating_and_phone_numbers_are_not_provided
    {
        static RequirePhoneNumbersInputValidator validator;
        static ValidationResult validation_results;
        static Mock<IRequirePhoneNumbers> require_phone_numbers;

        Establish context = () =>
        {
            validator = new RequirePhoneNumbersInputValidator();
            require_phone_numbers = new Mock<IRequirePhoneNumbers>();
            require_phone_numbers.SetupGet(m => m.PhoneNumbers).Returns((IEnumerable<string>)null);
        };

        Because of = () => { validation_results = validator.Validate(require_phone_numbers.Object); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();    
        It should_have_one_invalidation = () => validation_results.ShouldHaveInvalidCountOf(1);
        It should_indicate_that_phone_numbers_are_invalid = 
                () => validation_results.ShouldHaveInvalidProperty(nameof(require_phone_numbers.Object.PhoneNumbers));
    }      
}