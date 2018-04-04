using Machine.Specifications;
using su = Domain.StaffUser;
using System;
using System.Linq;
using Events.StaffUser;
using Concepts;
using Domain.StaffUser.Registering;
using Events.StaffUser.Registration;

namespace Domain.Specs.StaffUser.Registering.a_new_staff_data_verifier
{
    [Subject("Registering")]
    public class and_the_user_is_not_registered_and_there_are_no_optional_values
    {
        static su.StaffUser sut;
        static DateTimeOffset now;
        static RegisterNewStaffDataVerifier command;
        static bool is_new_registration;

        private Establish context = () => 
        {
            now = DateTimeOffset.UtcNow;
            command = given.commands.build_valid_instance<RegisterNewStaffDataVerifier>();
            command.Role.Sex = Sex.Female;
            command.Role.BirthYear = 1980;
            is_new_registration = true;
            sut = new su.StaffUser(command.Role.StaffUserId);
        };

        Because of = () => {
            sut.RegisterNewDataVerifier(is_new_registration, command.Role.FullName,command.Role.DisplayName,command.Role.Email,now,
                    command.Role.NationalSociety, command.Role.PreferredLanguage.Value, command.Role.PhoneNumbers, 
                    command.Role.BirthYear, command.Role.Sex, constants.valid_location);
        };

        It should_create_a_new_user_registed_event_with_the_correct_values 
            = () => sut.ShouldHaveEvent<NewUserRegistered>().AtBeginning().Where(
                e => e.FullName.ShouldEqual(command.Role.FullName),
                e => e.DisplayName.ShouldEqual(command.Role.DisplayName),
                e => e.Email.ShouldEqual(command.Role.Email),
                e => e.RegisteredAt.ShouldEqual(now)
            );

        It should_create_a_system_configurator_registered_event = () => {
            sut.ShouldHaveEvent<StaffDataVerifierRegistered>().InStream().Where(
                e => e.Latitude.ShouldEqual(constants.valid_location.Latitude),
                e => e.Longitude.ShouldEqual(constants.valid_location.Longitude),
                e => e.BirthYear.ShouldEqual(command.Role.BirthYear),
                e => e.Sex.ShouldEqual((int)command.Role.Sex.Value)
            );
        };
    }    
}