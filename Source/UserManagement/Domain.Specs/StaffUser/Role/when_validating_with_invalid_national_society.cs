using System;
using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Concepts;

namespace Domain.Specs.StaffUser.Role
{
    [Subject(typeof(RoleValidator))]
    public class when_validating_with_invalid_national_society
    {
        static RoleValidator validator;
        static ValidationResult validation_results;
        static Domain.StaffUser.Role role;

        Establish context = () =>
        {
            validator = new RoleValidator();
            role = given.role.build_instance_with(ei => ei.NationalSociety = Guid.Empty);
            role.YearOfBirth = 1980;
            role.Sex = Sex.Female;
        };

        Because of = () => { validation_results = validator.Validate(role); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();    
        It should_have_one_error = () => validation_results.ShouldHaveInvalidCountOf(1);
        It should_identify_national_society_as_the_error = () => validation_results.ShouldHaveInvalidProperty(nameof(extended.NationalSociety));      
    }
}