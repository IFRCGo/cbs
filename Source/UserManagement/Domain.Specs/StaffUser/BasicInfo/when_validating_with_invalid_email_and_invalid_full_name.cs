using Machine.Specifications;
using Domain.StaffUser;
using System;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Domain.Specs.StaffUser.BasicInfo
{
    [Subject(typeof(BasicInfoValidator))]
    public class when_validating_with_invalid_email_and_invalid_fullname
    {
        static BasicInfoValidator validator;
        static ValidationResult validation_results;
        static Domain.StaffUser.BasicInfo basic;

        Establish context = () =>
        {
            validator = new BasicInfoValidator();
            basic = given.basic_info.build_instance_with(
                bi => bi.Email = null, 
                bi => bi.FullName = null
            );
        };

        Because of = () => { validation_results = validator.Validate(basic); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid(); 
        It should_have_two_invalidations = () => validation_results.ShouldHaveInvalidCountOf(2); 
        It should_identify_the_email_as_the_error = () => validation_results.ShouldHaveInvalidProperty(nameof(basic.Email));  
        It should_identify_the_full_name_as_the_error = () => validation_results.ShouldHaveInvalidProperty(nameof(basic.FullName));  
    }
}