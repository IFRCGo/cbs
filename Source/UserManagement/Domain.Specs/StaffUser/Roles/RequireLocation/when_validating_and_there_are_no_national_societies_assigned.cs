using System;
using System.Collections.Generic;
using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Concepts;
using Moq;
using It = Machine.Specifications.It;

namespace Domain.Specs.StaffUser.Roles.RequireLocation
{
    [Subject(typeof(IRequireLocation))]
    public class when_validating_and_the_location_is_invalid
    {
        static RequireLocationValidator validator;
        static ValidationResult validation_results;
        static IRequireLocation location;

        Establish context = () =>
        {
            validator = new RequireLocationValidator();
            var mock = new Mock<IRequireLocation>();
            mock.SetupGet(m => m.Location).Returns(new Location(45,200));
            location = mock.Object;
        };

        Because of = () => { validation_results = validator.Validate(location); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();    
        It should_have_one_error = () => validation_results.ShouldHaveInvalidCountOf(1);
        It should_identify_location_as_the_error 
                            = () => validation_results.ShouldHaveInvalidProperty(nameof(location.Location));        
    }
}