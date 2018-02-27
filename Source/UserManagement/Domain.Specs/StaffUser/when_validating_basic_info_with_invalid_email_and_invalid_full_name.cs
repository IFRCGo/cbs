using Machine.Specifications;
using Domain.StaffUser;
using System;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Domain.Specs.StaffUser
{
    [Subject(typeof(BasicInfoValidator))]
    public class when_validating_basic_info_with_invalid_email_and_invalid_fullname
    {
        static BasicInfoValidator validator;
        static ValidationResult validation_results;
        static BasicInfo sut;

        Establish context = () =>
        {
            validator = new BasicInfoValidator();
            sut = new BasicInfo
            {
                StaffUserId = Guid.NewGuid(),
                Email = null,
                FullName = null
            };
        };

        Because of = () => { validation_results = validator.Validate(sut); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid(); 
        It should_have_two_invalidations = () => validation_results.ShouldHaveInvalidCountOf(2); 
        It should_identify_the_email_as_the_error = () => validation_results.ShouldHaveInvalidProperty(nameof(sut.Email));  
        It should_identify_the_full_name_as_the_error = () => validation_results.ShouldHaveInvalidProperty(nameof(sut.FullName));  
    }
}