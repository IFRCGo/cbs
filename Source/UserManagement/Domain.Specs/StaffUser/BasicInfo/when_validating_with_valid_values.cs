using Machine.Specifications;
using Domain.StaffUser;
using System;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Domain.Specs.StaffUser.BasicInfo
{
    [Subject(typeof(BasicInfoValidator))]
    public class when_validating_with_valid_values
    {
        static BasicInfoValidator validator;
        static ValidationResult validation_results;
        static Domain.StaffUser.BasicInfo basic;

        Establish context = () =>
        {
            validator = new BasicInfoValidator();
            basic = given.basic_info.build_valid_instance();
        };

        Because of = () => { validation_results = validator.Validate(basic); };

        It should_be_valid = () => validation_results.ShouldBeValid();    
    }
}