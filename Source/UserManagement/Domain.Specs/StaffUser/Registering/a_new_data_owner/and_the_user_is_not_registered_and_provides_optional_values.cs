// using Machine.Specifications;
// using su = Domain.StaffUser;
// using System;
// using Events.StaffUser;
// using Concepts;
// using Domain.StaffUser.Registering;
// using Domain.StaffUser.Roles;
// using Events.StaffUser.Registration;

// namespace Domain.Specs.StaffUser.Registering.a_new_data_owner
// {
//     [Subject("Registering")]
//     public class and_the_user_is_not_registered_and_provides_optional_values
//     {
//         static su.StaffUser sut;
//         static DateTimeOffset now;
//         static RegisterNewDataOwner cmd;
//         static DataOwner role;
//         static bool is_new_registration;

//         private Establish context = () =>
//         {
//             now = DateTimeOffset.UtcNow;
//             cmd = given.commands.build_valid_instance<RegisterNewDataOwner>();
//             sut = new su.StaffUser(cmd.Role.StaffUserId);
//             role = cmd.Role;
//             role.BirthYear = 1980;
//             role.Sex = Sex.Female;
//         };

//         Because of = () =>
//         {
//             sut.RegisterNewDataOwner(cmd.Role.FullName, cmd.Role.DisplayName, cmd.Role.Email,
//                 cmd.Role.NationalSociety, cmd.Role.PreferredLanguage.Value, cmd.Role.PhoneNumbers,
//                 cmd.Role.BirthYear, cmd.Role.Sex, cmd.Role.Position, cmd.Role.DutyStation, now);
//         };

//         It should_create_a_new_user_registed_event_with_the_correct_values
//             = () => sut.ShouldHaveEvent<NewUserRegistered>().AtBeginning().Where(
//                 e => e.FullName.ShouldEqual(role.FullName),
//                 e => e.DisplayName.ShouldEqual(role.DisplayName),
//                 e => e.Email.ShouldEqual(role.Email),
//                 e => e.RegisteredAt.ShouldEqual(now)
//             );

//         It should_create_a_system_configurator_registered_event = () =>
//         {
//             sut.ShouldHaveEvent<DataOwnerRegistered>().InStream().Where(
//                 e => e.Position.ShouldEqual(constants.valid_position),
//                 e => e.DutyStation.ShouldEqual(constants.valid_duty_station)
//             );
//         };
//     }
// }