// using Machine.Specifications;
// using FluentValidation.Results;
// using Domain.StaffUser;
// using Moq;
// using It = Machine.Specifications.It;
// using Concepts;

// namespace Domain.Specs.StaffUser.Roles.SupportSex
// {
//     [Subject(typeof(ISupportSex))]
//     public class when_validating_and_an_invalid_sex_is_provided
//     {
//         static SupportSexInputValidator validator;
//         static ValidationResult validation_results;
//         static Mock<ISupportSex> support_sex;

//         Establish context = () =>
//         {
//             validator = new SupportSexInputValidator();
//             support_sex = new Mock<ISupportSex>();
//             support_sex.SetupGet(m => m.Sex).Returns((Sex)10);
//         };

//         Because of = () => { validation_results = validator.Validate(support_sex.Object); };

//         It should_be_invalid = () => validation_results.ShouldBeInvalid();    
//         It should_have_one_invalidation = () => validation_results.ShouldHaveInvalidCountOf(1);
//         It should_identify_the_sex_as_the_problem = 
//             () => validation_results.ShouldHaveInvalidProperty(nameof(support_sex.Object.Sex));
//     }  
// }