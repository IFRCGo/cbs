using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Moq;
using It = Machine.Specifications.It;
using System;

namespace Domain.Specs.StaffUser.Roles.RequireNationalSociety
{
    [Subject(typeof(IRequireNationalSociety))]
    public class when_validating_and_national_society_is_not_valid
    {
        static RequireNationalSocietyInputValidator validator;
        static ValidationResult validation_results;
        static Mock<IRequireNationalSociety> require_national_society;

        Establish context = () =>
        {
            validator = new RequireNationalSocietyInputValidator();
            require_national_society = new Mock<IRequireNationalSociety>();
            require_national_society.SetupGet(m => m.NationalSociety).Returns(Guid.Empty);
        };

        Because of = () => { validation_results = validator.Validate(require_national_society.Object); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();    
        It should_have_one_invalidation = () => validation_results.ShouldHaveInvalidCountOf(1);
        It should_identify_national_society_as_the_problem = 
            () => validation_results.ShouldHaveInvalidProperty(nameof(require_national_society.Object.NationalSociety));
    }  
}