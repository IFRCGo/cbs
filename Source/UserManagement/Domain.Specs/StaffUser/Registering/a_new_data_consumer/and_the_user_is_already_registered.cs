using Machine.Specifications;
using su = Domain.StaffUser;
using System;

namespace Domain.Specs.StaffUser.Registering.a_new_data_consumer
{
    [Subject("Registering")]
    public class and_the_user_is_already_registered
    {
        static su.StaffUser sut;
        static DateTimeOffset now;
        static Domain.StaffUser.UserInfo user_info;
        static Domain.StaffUser.StaffDataConsumer role;
        static Exception result;

        Establish context = () => 
        {
            now = DateTimeOffset.UtcNow;
            user_info = StaffUser.UserInfo.given.user_info.build_valid_instance();
            role = StaffUser.Role.given.staff_role.build_valid_instance<Domain.StaffUser.StaffDataConsumer>();
            sut = new su.StaffUser(user_info.StaffUserId);

            //register the user so that they are already registered
            sut.RegisterNewDataConsumer(user_info.FullName,user_info.DisplayName,user_info.Email,now,
                    role.NationalSociety, role.PreferredLanguage, role.YearOfBirth, role.Sex, constants.valid_location);
        };

        Because of = () => result = Catch.Exception(
            () =>  sut.RegisterNewDataConsumer(user_info.FullName,user_info.DisplayName,user_info.Email,now,
                    role.NationalSociety, role.PreferredLanguage, role.YearOfBirth, role.Sex, constants.valid_location)
        );

        It should_throw_an_exception = () => result.ShouldNotBeNull();
        It should_be_a_user_already_registered_exception = () => result.ShouldBeOfExactType<UserAlreadyRegistered>();
    }
}