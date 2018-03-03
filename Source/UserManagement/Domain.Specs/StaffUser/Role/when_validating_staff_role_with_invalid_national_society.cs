using System;
using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Concepts;

namespace Domain.Specs.StaffUser.Role
{
    [Subject(typeof(RoleValidator))]
    public class when_validating_staff_role_with_invalid_national_society
    {
        static StaffRoleValidator validator;
        static ValidationResult validation_results;
        static Domain.StaffUser.StaffRole role;

        Establish context = () =>
        {
            validator = new StaffRoleValidator();
            role = given.staff_role.build_instance_with<Domain.StaffUser.SystemConfigurator>(ei => ei.NationalSociety = Guid.Empty);
            role.YearOfBirth = 1980;
            role.Sex = Sex.Female;
        };

        Because of = () => { validation_results = validator.Validate(role); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();    
        It should_have_one_error = () => validation_results.ShouldHaveInvalidCountOf(1);
        It should_identify_national_society_as_the_error = () => validation_results.ShouldHaveInvalidProperty(nameof(role.NationalSociety));      
    }
}