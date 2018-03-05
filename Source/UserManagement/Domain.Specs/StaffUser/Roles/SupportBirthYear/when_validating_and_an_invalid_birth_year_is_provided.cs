using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Moq;
using It = Machine.Specifications.It;

namespace Domain.Specs.StaffUser.Roles.SupportBirthYear
{
    [Subject(typeof(ISupportBirthYear))]
    public class when_validating_and_an_invalid_birth_year_is_provided
    {
        static SupportBirthYearInputValidator validator;
        static ValidationResult validation_results;
        static Mock<ISupportBirthYear> support_birth_year;

        Establish context = () =>
        {
            validator = new SupportBirthYearInputValidator();
            support_birth_year = new Mock<ISupportBirthYear>();
            support_birth_year.SetupGet(m => m.BirthYear).Returns(0);
        };

        Because of = () => { validation_results = validator.Validate(support_birth_year.Object); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();    
        It should_have_one_invalidation = () => validation_results.ShouldHaveInvalidCountOf(1);
        It should_identify_the_birth_year_as_the_problem = 
            () => validation_results.ShouldHaveInvalidProperty(nameof(support_birth_year.Object.BirthYear));
    }  
}