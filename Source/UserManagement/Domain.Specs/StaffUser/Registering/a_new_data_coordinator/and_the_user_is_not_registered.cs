using Machine.Specifications;
using su = Domain.StaffUser;
using System;
using Events.StaffUser;
using Concepts;
using Domain.StaffUser.Registering;
using Events.StaffUser.Registration;

namespace Domain.Specs.StaffUser.Registering.a_new_data_coordinator
{
    [Subject("Registering")]
    public class and_the_user_is_not_registered_and_provides_optional_values
    {
        static su.StaffUser sut;
        static DateTimeOffset now;
        static RegisterNewDataCoordinator cmd;
        static bool is_new_registration;

        private Establish context = () => 
        {
            now = DateTimeOffset.UtcNow;
            cmd = given.commands.build_valid_instance<RegisterNewDataCoordinator>();
            cmd.Role.BirthYear = 1980;
            cmd.Role.Sex = Sex.Female;
            is_new_registration = true;
            sut = new su.StaffUser(cmd.Role.StaffUserId);
        };

        Because of = () => {
            sut.RegisterNewDataCoordinator(is_new_registration, cmd.Role.FullName,cmd.Role.DisplayName,cmd.Role.Email,now,
                    cmd.Role.NationalSociety, cmd.Role.PreferredLanguage.Value, cmd.Role.PhoneNumbers,cmd.Role.AssignedNationalSocieties,
                    cmd.Role.BirthYear, cmd.Role.Sex);
        };

        It should_create_a_new_user_registed_event_with_the_correct_values 
            = () => sut.ShouldHaveEvent<NewUserRegistered>().AtBeginning().Where(
                e => e.FullName.ShouldEqual(cmd.Role.FullName),
                e => e.DisplayName.ShouldEqual(cmd.Role.DisplayName),
                e => e.Email.ShouldEqual(cmd.Role.Email),
                e => e.RegisteredAt.ShouldEqual(now)
            );

        It should_create_a_system_configurator_registered_event = () => {
            sut.ShouldHaveEvent<DataCoordinatorRegistered>().InStream().Where(
                e => e.NationalSociety.ShouldEqual(cmd.Role.NationalSociety),
                e => e.PreferredLanguage.ShouldEqual((int)cmd.Role.PreferredLanguage),
                e => e.Sex.ShouldEqual((int)cmd.Role.Sex.Value),
                e => e.BirthYear.ShouldEqual((int)cmd.Role.BirthYear)
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