using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Moq;
using It = Machine.Specifications.It;

namespace Domain.Specs.StaffUser.RequireBirthYear
{
    [Subject(typeof(IRequireBirthYear))]
    public class when_validating_and_birth_year_is_not_valid
    {
        static RequireBirthYearInputValidator validator;
        static ValidationResult validation_results;
        static Mock<IRequireBirthYear> require_birth_year;

        Establish context = () =>
        {
            validator = new RequireBirthYearInputValidator();
            require_birth_year = new Mock<IRequireBirthYear>();
            require_birth_year.SetupGet(m => m.BirthYear).Returns(0);
        };

        Because of = () => { validation_results = validator.Validate(require_birth_year.Object); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();    
        It should_have_one_invalidation = () => validation_results.ShouldHaveInvalidCountOf(1);
        It should_identify_the_birth_year_as_the_problem = 
            () => validation_results.ShouldHaveInvalidProperty(nameof(require_birth_year.Object.BirthYear));
    }  
}