using System;
using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Concepts;
using Moq;
using It = Machine.Specifications.It;

namespace Domain.Specs.StaffUser.RequireBirthYear
{
    [Subject(typeof(IRequireBirthYear))]
    public class when_validating_and_birth_year_is_valid
    {
        static RequireBirthYearInputValidator validator;
        static ValidationResult validation_results;
        static Mock<IRequireBirthYear> require_birth_year;

        Establish context = () =>
        {
            validator = new RequireBirthYearInputValidator();
            require_birth_year = new Mock<IRequireBirthYear>();
            require_birth_year.SetupGet(m => m.BirthYear).Returns(1980);
        };

        Because of = () => { validation_results = validator.Validate(require_birth_year.Object); };

        It should_be_valid = () => validation_results.ShouldBeValid();    
    }
}