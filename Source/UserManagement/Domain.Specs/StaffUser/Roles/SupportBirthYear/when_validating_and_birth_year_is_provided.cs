using System;
using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Concepts;
using Moq;
using It = Machine.Specifications.It;

namespace Domain.Specs.StaffUser.Roles.SupportBirthYear
{
    [Subject(typeof(ISupportBirthYear))]
    public class when_validating_and_birth_year_is_provided
    {
        static SupportBirthYearInputValidator validator;
        static ValidationResult validation_results;
        static Mock<ISupportBirthYear> support_birth_year;

        Establish context = () =>
        {
            validator = new SupportBirthYearInputValidator();
            support_birth_year = new Mock<ISupportBirthYear>();
            support_birth_year.SetupGet(m => m.BirthYear).Returns(1980);
        };

        Because of = () => { validation_results = validator.Validate(support_birth_year.Object); };

        It should_be_valid = () => validation_results.ShouldBeValid();    
    }
}