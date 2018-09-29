// using Machine.Specifications;
// using FluentValidation.Results;
// using Domain.StaffUser;
// using Moq;
// using It = Machine.Specifications.It;
// using System;

// namespace Domain.Specs.StaffUser.Roles.RequirePosition
// {
//     [Subject(typeof(IRequirePosition))]
//     public class when_validating_and_position_is_not_valid
//     {
//         static RequirePositionInputValidator validator;
//         static ValidationResult validation_results;
//         static Mock<IRequirePosition> require_position;

//         Establish context = () =>
//         {
//             validator = new RequirePositionInputValidator();
//             require_position = new Mock<IRequirePosition>();
//             require_position.SetupGet(m => m.Position).Returns(string.Empty);
//         };

//         Because of = () => { validation_results = validator.Validate(require_position.Object); };

//         It should_be_invalid = () => validation_results.ShouldBeInvalid();    
//         It should_have_one_invalidation = () => validation_results.ShouldHaveInvalidCountOf(1);
//         It should_identify_national_society_as_the_problem = 
//             () => validation_results.ShouldHaveInvalidProperty(nameof(require_position.Object.Position));
//     }  
// }