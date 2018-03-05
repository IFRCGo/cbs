using System;
using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Concepts;
using Moq;
using It = Machine.Specifications.It;

namespace Domain.Specs.StaffUser.Roles.RequireSex
{
    [Subject(typeof(IRequireSex))]
    public class when_validating_and_preferred_language_is_valid
    {
        static RequireSexInputValidator validator;
        static ValidationResult validation_results;
        static Mock<IRequireSex> require_sex;

        Establish context = () =>
        {
            validator = new RequireSexInputValidator();
            require_sex = new Mock<IRequireSex>();
            require_sex.SetupGet(m => m.Sex).Returns(Sex.Female);
        };

        Because of = () => { validation_results = validator.Validate(require_sex.Object); };

        It should_be_valid = () => validation_results.ShouldBeValid();    
    }
}