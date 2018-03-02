using Machine.Specifications;
using Domain.StaffUser;
using System;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Domain.Specs.StaffUser.BasicInfo
{
    [Subject(typeof(BasicInfoValidator))]
    public class when_validating_with_no_id
    {
        static BasicInfoValidator validator;
        static ValidationResult validation_results;
        static Domain.StaffUser.BasicInfo basic;

        Establish context = () =>
        {
            validator = new BasicInfoValidator();
            basic = given.basic_info.build_instance_with(bi => bi.StaffUserId = Guid.Empty);
        };

        Because of = () => { validation_results = validator.Validate(basic); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();  
        It should_identify_the_staff_user_id_as_the_error = () => validation_results.ShouldHaveInvalidProperty(nameof(basic.StaffUserId));  
    }
}