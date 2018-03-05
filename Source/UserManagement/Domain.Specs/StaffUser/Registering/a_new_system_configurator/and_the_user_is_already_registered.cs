using Machine.Specifications;
using su = Domain.StaffUser;
using System;
using Domain.StaffUser.Registering;
using Domain.StaffUser.Roles;

namespace Domain.Specs.StaffUser.Registering.a_new_system_configurator
{
    [Subject("Registering")]
    public class and_the_user_is_already_registered
    {
        static su.StaffUser sut;
        static DateTimeOffset now;
        static Exception result;
        static RegisterNewSystemConfigurator cmd;
        static SystemConfigurator role;

        private Establish context = () =>
        {
            now = DateTimeOffset.UtcNow;
            cmd = given.commands.build_valid_instance<RegisterNewSystemConfigurator>();
            role = cmd.Role;
            sut = new su.StaffUser(cmd.Role.StaffUserId);

            //register the user so that they are already registered
            sut.RegisterNewSystemConfigurator(role.FullName, role.DisplayName, role.Email, now,
                    role.NationalSociety, role.PreferredLanguage.Value, role.PhoneNumbers, new[] { Guid.NewGuid() },
                    role.BirthYear, role.Sex);
        };

        Because of = () => result = Catch.Exception(
            () => sut.RegisterNewSystemConfigurator(role.FullName, role.DisplayName, role.Email, now,
                    role.NationalSociety, role.PreferredLanguage.Value, role.PhoneNumbers, new[] { Guid.NewGuid() },
                    role.BirthYear, role.Sex)
        );

        It should_throw_an_exception = () => result.ShouldNotBeNull();
        It should_be_a_user_already_registered_exception = () => result.ShouldBeOfExactType<UserAlreadyRegistered>();
    }
}