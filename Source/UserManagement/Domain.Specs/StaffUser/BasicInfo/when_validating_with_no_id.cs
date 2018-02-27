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
        static Domain.StaffUser.BasicInfo extended;

        Establish context = () =>
        {
            validator = new BasicInfoValidator();
            extended = new Domain.StaffUser.BasicInfo
            {
                StaffUserId = Guid.Empty,
                Email = "user@redcross.no",
                FullName = "Our New User",
                DisplayName = "Joe"
            };
        };

        Because of = () => { validation_results = validator.Validate(extended); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();  
        It should_identify_the_staff_user_id_as_the_error = () => validation_results.ShouldHaveInvalidProperty(nameof(extended.StaffUserId));  
    }
}