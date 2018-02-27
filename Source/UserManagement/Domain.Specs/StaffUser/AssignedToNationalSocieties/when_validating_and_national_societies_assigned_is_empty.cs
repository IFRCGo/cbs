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
    public class when_validating_and_national_societies_assigned_is_empty
    {
        static AssignedToNationalSocietiesValidator validator;
        static ValidationResult validation_results;
        static Mock<IAmAssignedToNationalSocieties> assigned_to_national_societies;

        Establish context = () =>
        {
            validator = new AssignedToNationalSocietiesValidator();
            assigned_to_national_societies = new Mock<IAmAssignedToNationalSocieties>();
            assigned_to_national_societies.SetupGet(m => m.AssignedNationalSocieties).Returns(new List<Guid>());
        };

        Because of = () => { validation_results = validator.Validate(assigned_to_national_societies.Object); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();    
        It should_have_one_error = () => validation_results.ShouldHaveInvalidCountOf(1);
        It should_identify_assigned_national_societies_as_the_error 
                            = () => validation_results.ShouldHaveInvalidProperty(nameof(assigned_to_national_societies.Object.AssignedNationalSocieties));        
    }
}