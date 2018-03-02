using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Concepts;

namespace Domain.Specs.StaffUser.Role
{
    [Subject(typeof(RoleValidator))]
    public class when_validating_with_valid_values
    {
        static RoleValidator validator;
        static ValidationResult validation_results;
        static Domain.StaffUser.Role extended;

        Establish context = () =>
        {
            validator = new RoleValidator();
            extended = given.role.build_valid_instance();
        };

        Because of = () => { validation_results = validator.Validate(extended); };

        It should_be_valid = () => validation_results.ShouldBeValid();          
    }
}