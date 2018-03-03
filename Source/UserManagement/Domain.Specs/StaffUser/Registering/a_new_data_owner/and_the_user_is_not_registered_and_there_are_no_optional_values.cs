using Machine.Specifications;
using su = Domain.StaffUser;
using System;
using System.Linq;
using Events.StaffUser;
using Concepts;

namespace Domain.Specs.StaffUser.Registering.a_new_data_owner
{
    [Subject("Registering")]
    public class and_the_user_is_not_registered_and_there_are_no_optional_values
    {
        static su.StaffUser sut;
        static DateTimeOffset now;
        static Domain.StaffUser.UserInfo user_info;
        static Domain.StaffUser.DataOwner role;

        Establish context = () => 
        {
            now = DateTimeOffset.UtcNow;
            user_info = StaffUser.UserInfo.given.user_info.build_valid_instance();
            role = StaffUser.Role.given.staff_role.build_valid_instance<Domain.StaffUser.DataOwner>();
            sut = new su.StaffUser(user_info.StaffUserId);
        };

        Because of = () => {
            sut.RegisterNewDataOwner(user_info.FullName,user_info.DisplayName,user_info.Email,now,
                    role.NationalSociety, role.PreferredLanguage, role.YearOfBirth, role.Sex, 
                    data_owner_constants.valid_location, data_owner_constants.valid_position, 
                    data_owner_constants.valid_duty_station);
        };
        It should_create_a_new_user_registed_event_with_the_correct_values 
            = () => sut.ShouldHaveEvent<NewUserRegistered>().AtBeginning().Where(
                e => e.FullName.ShouldEqual(user_info.FullName),
                e => e.DisplayName.ShouldEqual(user_info.DisplayName),
                e => e.Email.ShouldEqual(user_info.Email),
                e => e.RegisteredAt.ShouldEqual(now)
            );

        It should_create_a_system_configurator_registered_event = () => {
            sut.ShouldHaveEvent<DataOwnerRegistered>().InStream().Where(
                e => e.Position.ShouldEqual(data_owner_constants.valid_position),
                e => e.DutyStation.ShouldEqual(data_owner_constants.valid_duty_station),
                e => e.Latitude.ShouldEqual(data_owner_constants.valid_location.Latitude),
                e => e.Longitude.ShouldEqual(data_owner_constants.valid_location.Longitude)
            );
        };
    }    
}