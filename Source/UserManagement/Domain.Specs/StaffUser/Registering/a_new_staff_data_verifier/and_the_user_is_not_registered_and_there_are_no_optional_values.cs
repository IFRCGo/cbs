using Machine.Specifications;
using su = Domain.StaffUser;
using System;
using System.Linq;
using Events.StaffUser;
using Concepts;

namespace Domain.Specs.StaffUser.Registering.a_new_staff_data_verifier
{
    [Subject("Registering")]
    public class and_the_user_is_not_registered_and_there_are_no_optional_values
    {
        static su.StaffUser sut;
        static DateTimeOffset now;
        static Domain.StaffUser.UserInfo user_info;
        static Domain.StaffUser.StaffDataVerifier role;

        Establish context = () => 
        {
            now = DateTimeOffset.UtcNow;
            user_info = StaffUser.Roles.UserInfo.given.user_info.build_valid_instance();
            role = StaffUser.Role.given.staff_role.build_valid_instance<Domain.StaffUser.StaffDataVerifier>();
            role.Sex = Sex.Female;
            role.YearOfBirth = 1980;
            sut = new su.StaffUser(user_info.StaffUserId);
        };

        Because of = () => {
            sut.RegisterNewDataVerifier(user_info.FullName,user_info.DisplayName,user_info.Email,now,
                    role.NationalSociety, role.PreferredLanguage, role.PhoneNumbers, role.YearOfBirth, role.Sex, 
                    data_owner_constants.valid_location);
        };
        It should_create_a_new_user_registed_event_with_the_correct_values 
            = () => sut.ShouldHaveEvent<NewUserRegistered>().AtBeginning().Where(
                e => e.FullName.ShouldEqual(user_info.FullName),
                e => e.DisplayName.ShouldEqual(user_info.DisplayName),
                e => e.Email.ShouldEqual(user_info.Email),
                e => e.RegisteredAt.ShouldEqual(now)
            );

        It should_create_a_system_configurator_registered_event = () => {
            sut.ShouldHaveEvent<StaffDataVerifierRegistered>().InStream().Where(
                e => e.Latitude.ShouldEqual(constants.valid_location.Latitude),
                e => e.Longitude.ShouldEqual(constants.valid_location.Longitude),
                e => e.BirthYear.ShouldEqual(role.YearOfBirth.Value),
                e => e.Sex.ShouldEqual((int)role.Sex.Value)
            );
        };
    }    
}