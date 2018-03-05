using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Moq;
using It = Machine.Specifications.It;
using Concepts;

namespace Domain.Specs.StaffUser.Roles.RequirePreferredLanguage
{
    [Subject(typeof(IRequirePreferredLanguage))]
    public class when_validating_and_preferred_language_is_not_valid
    {
        static RequirePreferredLanguageInputValidator validator;
        static ValidationResult validation_results;
        static Mock<IRequirePreferredLanguage> require_preferred_language;

        Establish context = () =>
        {
            validator = new RequirePreferredLanguageInputValidator();
            require_preferred_language = new Mock<IRequirePreferredLanguage>();
            require_preferred_language.SetupGet(m => m.PreferredLanguage).Returns((Language)10);
        };

        Because of = () => { validation_results = validator.Validate(require_preferred_language.Object); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();    
        It should_have_one_invalidation = () => validation_results.ShouldHaveInvalidCountOf(1);
        It should_identify_preferred_language_as_the_problem = 
            () => validation_results.ShouldHaveInvalidProperty(nameof(require_preferred_language.Object.PreferredLanguage));
    }  
}