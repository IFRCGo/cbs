using System;
using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Concepts;
using Moq;
using It = Machine.Specifications.It;

namespace Domain.Specs.StaffUser.Roles.RequireNationalSociety
{
    [Subject(typeof(IRequireNationalSociety))]
    public class when_validating_and_national_society_is_valid
    {
        static RequireNationalSocietyInputValidator validator;
        static ValidationResult validation_results;
        static Mock<IRequireNationalSociety> require_national_society;

        Establish context = () =>
        {
            validator = new RequireNationalSocietyInputValidator();
            require_national_society = new Mock<IRequireNationalSociety>();
            require_national_society.SetupGet(m => m.NationalSociety).Returns(Guid.NewGuid());
        };

        Because of = () => { validation_results = validator.Validate(require_national_society.Object); };

        It should_be_valid = () => validation_results.ShouldBeValid();    
    }
}