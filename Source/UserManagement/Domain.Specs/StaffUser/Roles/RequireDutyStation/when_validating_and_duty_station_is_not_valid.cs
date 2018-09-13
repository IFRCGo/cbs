// using Machine.Specifications;
// using FluentValidation.Results;
// using Domain.StaffUser;
// using Moq;
// using It = Machine.Specifications.It;
// using System;

// namespace Domain.Specs.StaffUser.Roles.RequireDutyStation
// {
//     [Subject(typeof(IRequireDutyStation))]
//     public class when_validating_and_duty_station_is_not_valid
//     {
//         static RequireDutyStationInputValidator validator;
//         static ValidationResult validation_results;
//         static Mock<IRequireDutyStation> require_duty_station;

//         Establish context = () =>
//         {
//             validator = new RequireDutyStationInputValidator();
//             require_duty_station = new Mock<IRequireDutyStation>();
//             require_duty_station.SetupGet(m => m.DutyStation).Returns(string.Empty);
//         };

//         Because of = () => { validation_results = validator.Validate(require_duty_station.Object); };

//         It should_be_invalid = () => validation_results.ShouldBeInvalid();    
//         It should_have_one_invalidation = () => validation_results.ShouldHaveInvalidCountOf(1);
//         It should_identify_national_society_as_the_problem = 
//             () => validation_results.ShouldHaveInvalidProperty(nameof(require_duty_station.Object.DutyStation));
//     }  
// }