// using System;
// using Machine.Specifications;
// using FluentValidation.Results;
// using Domain.StaffUser;
// using Concepts;
// using Moq;
// using It = Machine.Specifications.It;

// namespace Domain.Specs.StaffUser.Roles.SupportSex
// {
//     [Subject(typeof(ISupportSex))]
//     public class when_validating_and_sex_is_provided
//     {
//         static SupportSexInputValidator validator;
//         static ValidationResult validation_results;
//         static Mock<ISupportSex> support_sex;

//         Establish context = () =>
//         {
//             validator = new SupportSexInputValidator();
//             support_sex = new Mock<ISupportSex>();
//             support_sex.SetupGet(m => m.Sex).Returns(Sex.Female);
//         };

//         Because of = () => { validation_results = validator.Validate(support_sex.Object); };

//         It should_be_valid = () => validation_results.ShouldBeValid();    
//     }
// }