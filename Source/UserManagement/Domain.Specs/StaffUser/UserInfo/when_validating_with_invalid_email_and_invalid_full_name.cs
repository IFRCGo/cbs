using Machine.Specifications;
using Domain.StaffUser;
using System;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Domain.Specs.StaffUser.UserInfo
{
    [Subject(typeof(UserInfoValidator))]
    public class when_validating_with_invalid_email_and_invalid_fullname
    {
        static UserInfoValidator validator;
        static ValidationResult validation_results;
        static Domain.StaffUser.UserInfo basic;

        Establish context = () =>
        {
            validator = new UserInfoValidator();
            basic = given.user_info.build_instance_with(
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