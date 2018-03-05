using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Moq;
using It = Machine.Specifications.It;
using Concepts;

namespace Domain.Specs.StaffUser.Roles.RequireSex
{
    [Subject(typeof(IRequireSex))]
    public class when_validating_and_sex_is_not_valid
    {
        static RequireSexInputValidator validator;
        static ValidationResult validation_results;
        static Mock<IRequireSex> require_sex;

        Establish context = () =>
        {
            validator = new RequireSexInputValidator();
            require_sex = new Mock<IRequireSex>();
            require_sex.SetupGet(m => m.Sex).Returns((Sex)10);
        };

        Because of = () => { validation_results = validator.Validate(require_sex.Object); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();    
        It should_have_one_invalidation = () => validation_results.ShouldHaveInvalidCountOf(1);
        It should_identify_sex_as_the_problem = 
            () => validation_results.ShouldHaveInvalidProperty(nameof(require_sex.Object.Sex));
    }  
}