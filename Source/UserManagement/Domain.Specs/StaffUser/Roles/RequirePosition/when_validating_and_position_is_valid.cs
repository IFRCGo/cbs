// using System;
// using Machine.Specifications;
// using FluentValidation.Results;
// using Domain.StaffUser;
// using Concepts;
// using Moq;
// using It = Machine.Specifications.It;

// namespace Domain.Specs.StaffUser.Roles.RequirePosition
// {
//     [Subject(typeof(IRequirePosition))]
//     public class when_validating_and_position_is_valid
//     {
//         static RequirePositionInputValidator validator;
//         static ValidationResult validation_results;
//         static Mock<IRequirePosition> require_position;

//         Establish context = () =>
//         {
//             validator = new RequirePositionInputValidator();
//             require_position = new Mock<IRequirePosition>();
//             require_position.SetupGet(m => m.Position).Returns("position");
//         };

//         Because of = () => { validation_results = validator.Validate(require_position.Object); };

//         It should_be_valid = () => validation_results.ShouldBeValid();    
//     }
// }