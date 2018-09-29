// using Machine.Specifications;
// using Domain.StaffUser;
// using System;
// using FluentValidation.Results;
// using System.Collections.Generic;

// namespace Domain.Specs.StaffUser.Roles.UserInfo
// {
//     [Subject(typeof(UserInfoValidator))]
//     public class when_validating_with_valid_values
//     {
//         static UserInfoValidator validator;
//         static ValidationResult validation_results;
//         static Domain.StaffUser.UserInfo basic;

//         Establish context = () =>
//         {
//             validator = new UserInfoValidator();
//             basic = given.user_info.build_valid_instance();
//         };

//         Because of = () => { validation_results = validator.Validate(basic); };

//         It should_be_valid = () => validation_results.ShouldBeValid();    
//     }
// }