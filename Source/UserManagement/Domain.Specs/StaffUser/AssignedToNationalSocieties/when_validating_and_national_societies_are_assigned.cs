using System;
using System.Collections.Generic;
using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Concepts;
using Moq;
using It = Machine.Specifications.It;

namespace Domain.Specs.StaffUser.AssignedToNationalSocieties
{
    [Subject(typeof(IAmAssignedToNationalSocieties))]
    public class when_validating_and_national_societies_are_assigned
    {
        static AssignedToNationalSocietiesInputValidator validator;
        static ValidationResult validation_results;
        static Mock<IAmAssignedToNationalSocieties> assigned_to_national_societies;

        Establish context = () =>
        {
            validator = new AssignedToNationalSocietiesInputValidator();
            assigned_to_national_societies = new Mock<IAmAssignedToNationalSocieties>();
            assigned_to_national_societies.SetupGet(m => m.AssignedNationalSocieties).Returns(new []{ Guid.NewGuid() });
        };

        Because of = () => { validation_results = validator.Validate(assigned_to_national_societies.Object); };

        It should_be_valid = () => validation_results.ShouldBeValid();    
    }
}