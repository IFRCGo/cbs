using Machine.Specifications;
using Domain.StaffUser;
using System;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Domain.Specs.StaffUser.BasicInfo
{
    [Subject(typeof(BasicInfoValidator))]
    public class when_validating_with_invalid_full_name
    {
        static BasicInfoValidator validator;
        static ValidationResult validation_results;
        static Domain.StaffUser.BasicInfo sut;

        Establish context = () =>
        {
            validator = new BasicInfoValidator();
            sut = new Domain.StaffUser.BasicInfo
            {
                StaffUserId = Guid.NewGuid(),
                Email = "user@redcross.no",
                FullName = null
            };
        };

        Because of = () => { validation_results = validator.Validate(sut); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();  
        It should_identify_the_full_name_as_the_error = () => validation_results.ShouldHaveInvalidProperty(nameof(sut.FullName));  
    }
}