using Machine.Specifications;
using Domain.StaffUser;
using System;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Domain.Specs.StaffUser.Roles.UserInfo
{
    [Subject(typeof(UserInfoValidator))]
    public class when_validating_with_invalid_full_name
    {
        static UserInfoValidator validator;
        static ValidationResult validation_results;
        static Domain.StaffUser.UserInfo basic;

        Establish context = () =>
        {
            validator = new UserInfoValidator();
            basic = given.user_info.build_instance_with(bi => bi.FullName = null);
        };

        Because of = () => { validation_results = validator.Validate(basic); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();  
        It should_identify_the_full_name_as_the_error = () => validation_results.ShouldHaveInvalidProperty(nameof(basic.FullName));  
    }
}