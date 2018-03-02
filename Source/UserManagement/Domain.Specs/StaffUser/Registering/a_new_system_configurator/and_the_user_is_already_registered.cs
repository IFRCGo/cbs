using Machine.Specifications;
using su = Domain.StaffUser;
using System;

namespace Domain.Specs.StaffUser.Registering.a_new_system_configurator
{
    [Subject("Registering")]
    public class and_the_user_is_already_registered
    {
        static su.StaffUser sut;
        static DateTimeOffset now;
        static Domain.StaffUser.UserInfo user_info;
        static Domain.StaffUser.Role role;
        static Exception result;

        Establish context = () => 
        {
            now = DateTimeOffset.UtcNow;
            user_info = StaffUser.UserInfo.given.user_info.build_valid_instance();
            role = StaffUser.Role.given.role.build_valid_instance();
            sut = new su.StaffUser(user_info.StaffUserId);

            //register the user so that they are already registered
            sut.RegisterNewSystemConfigurator(user_info.FullName,user_info.DisplayName,user_info.Email,now,
                    role.NationalSociety, role.PreferredLanguage, role.PhoneNumbers, new[] { Guid.NewGuid() },
                    role.YearOfBirth, role.Sex);
        };

        Because of = () => result = Catch.Exception(
            () =>  sut.RegisterNewSystemConfigurator(user_info.FullName,user_info.DisplayName,user_info.Email,now,
                    role.NationalSociety, role.PreferredLanguage, role.PhoneNumbers, new[] { Guid.NewGuid() },
                    role.YearOfBirth, role.Sex)
        );

        It should_throw_an_exception = () => result.ShouldNotBeNull();
        It should_be_a_user_already_registered_exception = () => result.ShouldBeOfExactType<UserAlreadyRegistered>();
    }
}