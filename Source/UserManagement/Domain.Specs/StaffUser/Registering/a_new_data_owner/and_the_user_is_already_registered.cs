using Machine.Specifications;
using su = Domain.StaffUser;
using System;
using Concepts;

namespace Domain.Specs.StaffUser.Registering.a_new_data_owner
{
    [Subject("Registering")]
    public class and_the_user_is_already_registered
    {
        static su.StaffUser sut;
        static DateTimeOffset now;
        static Domain.StaffUser.UserInfo user_info;
        static Domain.StaffUser.DataOwner role;
        static Exception result;

        Establish context = () => 
        {
            now = DateTimeOffset.UtcNow;
            user_info = StaffUser.UserInfo.given.user_info.build_valid_instance();
            role = StaffUser.Role.given.staff_role.build_valid_instance<Domain.StaffUser.DataOwner>();
            sut = new su.StaffUser(user_info.StaffUserId);


            //register the user so that they are already registered
            sut.RegisterNewDataOwner(user_info.FullName,user_info.DisplayName,user_info.Email,now,
                    role.NationalSociety, role.PreferredLanguage,role.YearOfBirth, role.Sex, 
                    data_owner_constants.valid_location, data_owner_constants.valid_position, 
                    data_owner_constants.valid_duty_station);
        };

        Because of = () => result = Catch.Exception(
            () =>  sut.RegisterNewDataOwner(user_info.FullName,user_info.DisplayName,user_info.Email,now,
                    role.NationalSociety, role.PreferredLanguage,role.YearOfBirth, role.Sex, 
                    data_owner_constants.valid_location, data_owner_constants.valid_position, 
                    data_owner_constants.valid_duty_station)
        );

        It should_throw_an_exception = () => result.ShouldNotBeNull();
        It should_be_a_user_already_registered_exception = () => result.ShouldBeOfExactType<UserAlreadyRegistered>();
    }
}