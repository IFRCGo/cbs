using System;
using System.Collections.Generic;
using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Concepts;
using Moq;
using It = Machine.Specifications.It;

namespace Domain.Specs.StaffUser.HaveALocation
{
    [Subject(typeof(IHaveALocation))]
    public class when_validating_and_location_is_missing
    {
        static HaveALocationValidator validator;
        static ValidationResult validation_results;
        static IHaveALocation location;

        Establish context = () =>
        {
            validator = new HaveALocationValidator();
            var mock = new Mock<IHaveALocation>();
            mock.SetupGet(m => m.Location).Returns((Location)null);
            location = mock.Object;
        };

        Because of = () => { validation_results = validator.Validate(location);};

        It should_be_invalid = () => validation_results.ShouldBeInvalid();    
        It should_have_one_error = () => validation_results.ShouldHaveInvalidCountOf(1);
        It should_identify_location_as_the_error 
                            = () => validation_results.ShouldHaveInvalidProperty(nameof(location.Location));        
    }
}