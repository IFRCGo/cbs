using System;
using System.Collections.Generic;
using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Concepts;
using Moq;
using It = Machine.Specifications.It;

namespace Domain.Specs.StaffUser.Roles.AssignedToNationalSocieties
{
    [Subject(typeof(IRequireLocation))]
    public class when_validating_and_valid_location_is_present
    {
        static RequireLocationValidator validator;
        static ValidationResult validation_results;
        static IRequireLocation location;

        Establish context = () =>
        {
            validator = new RequireLocationValidator();
            var locationMock = new Mock<IRequireLocation>();
            locationMock.SetupGet(m => m.Location).Returns(new Location(40,40));
            location = locationMock.Object;
        };

        Because of = () => { validation_results = validator.Validate(location); };

        It should_be_valid = () => validation_results.ShouldBeValid();    
    }
}