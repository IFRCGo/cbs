// using Machine.Specifications;
// using Dolittle.Time;
// using Dolittle.Domain;
// using Domain.StaffUser;
// using Domain.StaffUser.Registering;
// using Events.StaffUser;
// using Moq;
// using System;
// using Events.StaffUser.Registration;
// using It = Machine.Specifications.It;

// namespace Domain.Specs.StaffUser.Registering.a_new_data_coordinator
// {
//     [Subject("Registering")]
//     public class handling_a_register_data_coordinator_command
//     {
//         static RegisteringCommandHandlers command_handlers;
//         static RegisterNewDataCoordinator command; 
//         static Mock<IAggregateRootRepositoryFor<Domain.StaffUser.StaffUser>> repository;
//         static Mock<ISystemClock> system_clock;
//         static Domain.StaffUser.StaffUser staff_user;
//         static DateTimeOffset now;

//         Establish context = () => 
//         {
//             command = given.commands.build_valid_instance<RegisterNewDataCoordinator>();
//             staff_user = new Domain.StaffUser.StaffUser(command.Role.StaffUserId);
//             repository = new Mock<IAggregateRootRepositoryFor<Domain.StaffUser.StaffUser>>();
//             repository.Setup(r => r.Get(command.Role.StaffUserId)).Returns(staff_user);
//             now = DateTimeOffset.UtcNow;
//             system_clock = new Mock<ISystemClock>();
//             system_clock.Setup(c => c.GetCurrentTime()).Returns(now);

//             command_handlers = new RegisteringCommandHandlers(repository.Object, system_clock.Object);
//         };

//         Because of = () => command_handlers.Handle(command);

//         It should_attempt_to_retrieve_the_staff_user = () => repository.VerifyAll();
//         It should_get_the_time_from_the_system_clock = () => system_clock.VerifyAll();
//         It call_the_register_new_data_coordinator_user_method_with_the_correct_parameters = () => 
//         {
//             staff_user.ShouldHaveEvent<NewUserRegistered>().AtBeginning().Where(
//                 e => e.StaffUserId.ShouldEqual(command.Role.StaffUserId),
//                 e => e.FullName.ShouldEqual(command.Role.FullName),
//                 e => e.DisplayName.ShouldEqual(command.Role.DisplayName),
//                 e => e.Email.ShouldEqual(command.Role.Email),
//                 e => e.RegisteredAt.ShouldEqual(now)
//             );

//             staff_user.ShouldHaveEvent<DataCoordinatorRegistered>().InStream().Where(
//                 e => e.NationalSociety.ShouldEqual(command.Role.NationalSociety),
//                 e => e.PreferredLanguage.ShouldEqual((int)command.Role.PreferredLanguage)
//             );
//         };
//     }
// }