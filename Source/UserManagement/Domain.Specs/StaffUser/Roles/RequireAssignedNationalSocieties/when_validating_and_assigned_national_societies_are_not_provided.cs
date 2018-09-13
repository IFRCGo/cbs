// using System;
// using System.Collections.Generic;
// using Machine.Specifications;
// using FluentValidation.Results;
// using Domain.StaffUser;
// using Concepts;
// using Moq;
// using It = Machine.Specifications.It;

// namespace Domain.Specs.StaffUser.Roles.RequireAssignedNationalSocieties
// {

//      [Subject(typeof(IRequireAssignedNationalSocieties))]
//     public class when_validating_and_assigned_national_societies_are_not_provided
//     {
//         static RequireAssignedNationalSocietiesInputValidator validator;
//         static ValidationResult validation_results;
//         static Mock<IRequireAssignedNationalSocieties> require_assigned_national_societies;

//         Establish context = () =>
//         {
//             validator = new RequireAssignedNationalSocietiesInputValidator();
//             require_assigned_national_societies = new Mock<IRequireAssignedNationalSocieties>();
//             require_assigned_national_societies.SetupGet(m => m.AssignedNationalSocieties).Returns((IEnumerable<Guid>)null);
//         };

//         Because of = () => { validation_results = validator.Validate(require_assigned_national_societies.Object); };

//         It should_be_invalid = () => validation_results.ShouldBeInvalid();    
//         It should_have_one_invalidation = () => validation_results.ShouldHaveInvalidCountOf(1);
//         It should_indicate_that_phone_numbers_are_invalid = 
//                 () => validation_results.ShouldHaveInvalidProperty(nameof(require_assigned_national_societies.Object.AssignedNationalSocieties));
//     }      
// }