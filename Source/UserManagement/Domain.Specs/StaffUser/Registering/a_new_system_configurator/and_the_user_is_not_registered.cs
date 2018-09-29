// using Machine.Specifications;
// using su = Domain.StaffUser;
// using System;
// using Events.StaffUser;
// using Concepts;
// using Domain.Specs.StaffUser.Roles.UserInfo.given;
// using Domain.StaffUser.Registering;
// using Domain.StaffUser.Roles;
// using Events.StaffUser.Registration;

// namespace Domain.Specs.StaffUser.Registering.a_new_system_configurator
// {
//     [Subject("Registering")]
//     public class and_the_user_is_not_registered_and_provides_optional_values
//     {
//         static su.StaffUser sut;
//         static DateTimeOffset now;
//         static RegisterNewSystemConfigurator cmd;
//         static SystemConfigurator role;
//         static bool is_new_registration;

//         private Establish context = () =>
//         {
//             now = DateTimeOffset.UtcNow;
//             cmd = given.commands.build_valid_instance<RegisterNewSystemConfigurator>();
//             role = cmd.Role;
//             role.BirthYear = 1980;
//             role.Sex = Sex.Female;
//             sut = new su.StaffUser(role.StaffUserId);
//         };

//         Because of = () =>
//         {
//             sut.RegisterNewSystemConfigurator(role.FullName, role.DisplayName, role.Email,
//                     role.NationalSociety, role.PreferredLanguage.Value, role.PhoneNumbers, role.AssignedNationalSocieties,
//                     role.BirthYear, role.Sex, now);
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
//             sut.ShouldHaveEvent<SystemConfiguratorRegistered>().InStream().Where(
//                 e => e.NationalSociety.ShouldEqual(role.NationalSociety),
//                 e => e.PreferredLanguage.ShouldEqual((int)role.PreferredLanguage),
//                 e => e.Sex.ShouldEqual((int)role.Sex.Value),
//                 e => e.BirthYear.ShouldEqual((int)role.BirthYear.Value)
//             );
//         };

//         It should_create_a_national_society_assigned_for_each_national_society = () =>
//         {
//             sut.ShouldHaveEvent<NationalSocietyAssignedToSystemConfigurator>().Instances(2);
//         };

//         It should_create_a_phone_number_registered_event_for_each_phone_number = () =>
//         {
//             sut.ShouldHaveEvent<PhoneNumberAddedToSystemConfigurator>().Instances(2);
//         };
//     }
// }