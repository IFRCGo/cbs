// using System;
// using Machine.Specifications;
// using FluentValidation.Results;
// using Domain.StaffUser;
// using Concepts;
// using Moq;
// using It = Machine.Specifications.It;

// namespace Domain.Specs.StaffUser.Roles.RequireDutyStation
// {
//     [Subject(typeof(IRequireDutyStation))]
//     public class when_validating_and_duty_station_is_valid
//     {
//         static RequireDutyStationInputValidator validator;
//         static ValidationResult validation_results;
//         static Mock<IRequireDutyStation> require_duty_station;

//         Establish context = () =>
//         {
//             validator = new RequireDutyStationInputValidator();
//             require_duty_station = new Mock<IRequireDutyStation>();
//             require_duty_station.SetupGet(m => m.DutyStation).Returns("duty station");
//         };

//         Because of = () => { validation_results = validator.Validate(require_duty_station.Object); };

//         It should_be_valid = () => validation_results.ShouldBeValid();    
//     }
// }