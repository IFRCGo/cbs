using Machine.Specifications;
using su = Domain.StaffUser;
using System;
using System.Linq;
using Events.StaffUser;
using Concepts;

namespace Domain.Specs.StaffUser.Registering.a_new_system_configurator
{
    [Subject("Registering")]
    public class and_the_user_is_not_registered_and_there_are_no_optional_values
    {
        static su.StaffUser sut;
        static DateTimeOffset now;
        static Domain.StaffUser.UserInfo user_info;
        static Domain.StaffUser.Role role;
        static Guid[] assigned_national_societies;

        Establish context = () => 
        {
            now = DateTimeOffset.UtcNow;
            user_info = StaffUser.UserInfo.given.user_info.build_valid_instance();
            role = StaffUser.Role.given.role.build_valid_instance();
            assigned_national_societies = new Guid[]{ Guid.NewGuid(), Guid.NewGuid() };
            sut = new su.StaffUser(user_info.StaffUserId);
        };

        Because of = () => {
            sut.RegisterNewSystemConfigurator(user_info.FullName,user_info.DisplayName,user_info.Email,now,
                    role.NationalSociety, role.PreferredLanguage, role.PhoneNumbers, assigned_national_societies,
                    role.YearOfBirth, role.Sex);
        };
        It should_create_a_new_user_registed_event_with_the_correct_values 
            = () => sut.ShouldHaveEvent<NewUserRegistered>().AtBeginning().Where(
                e => e.FullName.ShouldEqual(user_info.FullName),
                e => e.DisplayName.ShouldEqual(user_info.DisplayName),
                e => e.Email.ShouldEqual(user_info.Email),
                e => e.RegisteredAt.ShouldEqual(now)
            );

        It should_create_a_system_configurator_registered_event = () => {
            sut.ShouldHaveEvent<SystemConfiguratorRegistered>().InStream().Where(
                e => e.NationalSociety.ShouldEqual(role.NationalSociety),
                e => e.PreferredLanguage.ShouldEqual((int)role.PreferredLanguage),
                e => e.Sex.ShouldEqual(Constants.NOT_KNOWN),
                e => e.BirthYear.ShouldEqual(Constants.NOT_KNOWN)
            );
        };

        It should_create_a_national_society_assigned_for_each_national_society = () => {
            sut.ShouldHaveEvent<NationalSocietyAssigned>().Instances(2);
        };

        It should_create_a_phone_number_registered_event_for_each_phone_number = () => {
            sut.ShouldHaveEvent<PhoneNumberRegistered>().Instances(2);
        };
    }    
}