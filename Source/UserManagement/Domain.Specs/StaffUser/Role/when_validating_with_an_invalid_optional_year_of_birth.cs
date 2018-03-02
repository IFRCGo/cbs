using System;
using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Concepts;

namespace Domain.Specs.StaffUser.Role
{
    [Subject(typeof(RoleValidator))]
    public class when_validating_with_an_invalid_optional_year_of_birth
    {
        static RoleValidator validator;
        static ValidationResult validation_results;
        static Domain.StaffUser.Role extended;

        Establish context = () =>
        {
            validator = new RoleValidator();
            extended = given.role.build_instance_with(ei => ei.YearOfBirth = 1);
            extended.Sex = Sex.Female;
        };

        Because of = () => { validation_results = validator.Validate(extended); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();    
        It should_have_one_error = () => validation_results.ShouldHaveInvalidCountOf(1);
        It should_identify_year_of_birth_as_the_error = () => validation_results.ShouldHaveInvalidProperty(nameof(extended.YearOfBirth));      
    }
}