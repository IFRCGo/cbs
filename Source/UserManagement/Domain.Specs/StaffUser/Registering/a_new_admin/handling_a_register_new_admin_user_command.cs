using Machine.Specifications;
using doLittle.Time;
using doLittle.Domain;
using Domain.StaffUser;
using Domain.StaffUser.Registering;
using Events.StaffUser;
using Moq;
using System;
using It = Machine.Specifications.It;
using given = Domain.Specs.StaffUser.Roles.UserInfo.given;

namespace Domain.Specs.StaffUser.Registering.a_new_admin
{
    [Subject("Registering")]
    public class handling_a_register_new_admin_user_command
    {
        static RegisteringCommandHandlers command_handlers;
        static RegisterNewAdminUser command; 
        static Mock<IAggregateRootRepositoryFor<Domain.StaffUser.StaffUser>> repository;
        static Mock<ISystemClock> system_clock;
        static Domain.StaffUser.StaffUser staff_user;
        static DateTimeOffset now;

        Establish context = () => 
        {
            command = new RegisterNewAdminUser
            {
                UserDetails = given.user_info.build_valid_instance()
            };
            staff_user = new Domain.StaffUser.StaffUser(command.UserDetails.StaffUserId);
            repository = new Mock<IAggregateRootRepositoryFor<Domain.StaffUser.StaffUser>>();
            repository.Setup(r => r.Get(command.UserDetails.StaffUserId)).Returns(staff_user);
            now = DateTimeOffset.UtcNow;
            system_clock = new Mock<ISystemClock>();
            system_clock.Setup(c => c.GetCurrentTime()).Returns(now);

            command_handlers = new RegisteringCommandHandlers(repository.Object, system_clock.Object);
        };

        Because of = () => command_handlers.Handle(command);

        It should_attempt_to_retrieve_the_staff_user = () => repository.VerifyAll();
        It should_get_the_time_from_the_system_clock = () => system_clock.VerifyAll();
        It call_the_register_new_admin_user_method_with_the_correct_parameters = () => 
        {
            staff_user.ShouldHaveEvent<NewUserRegistered>().AtBeginning().Where(
                e => e.StaffUserId.ShouldEqual(command.UserDetails.StaffUserId),
                e => e.FullName.ShouldEqual(command.UserDetails.FullName),
                e => e.DisplayName.ShouldEqual(command.UserDetails.DisplayName),
                e => e.Email.ShouldEqual(command.UserDetails.Email),
                e => e.RegisteredAt.ShouldEqual(now)
            );
        };
    }
}