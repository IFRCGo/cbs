using Machine.Specifications;
using su = Domain.StaffUser;
using System;
using System.Linq;
using Events.StaffUser;
using Concepts;
using Domain.StaffUser.Registering;

namespace Domain.Specs.StaffUser.Registering.a_new_data_consumer
{
    [Subject("Registering")]
    public class and_the_user_is_not_registered_and_there_are_no_optional_values
    {
        static su.StaffUser sut;
        static DateTimeOffset now;
        static RegisterNewStaffDataConsumer command;
        Establish context = () => 
        {
            now = DateTimeOffset.UtcNow;
            command = given.commands.build_valid_instance<RegisterNewStaffDataConsumer>();
            sut = new su.StaffUser(command.Role.StaffUserId);
        };

        Because of = () => {
            sut.RegisterNewDataConsumer(command.Role.FullName,command.Role.DisplayName,command.Role.Email,now,
                                        command.Role.NationalSociety, command.Role.PreferredLanguage.Value, command.Role.BirthYear, 
                                        command.Role.Sex, constants.valid_location);
        };
        It should_create_a_new_user_registed_event_with_the_correct_values 
            = () => sut.ShouldHaveEvent<NewUserRegistered>().AtBeginning().Where(
                e => e.FullName.ShouldEqual(command.Role.FullName),
                e => e.DisplayName.ShouldEqual(command.Role.DisplayName),
                e => e.Email.ShouldEqual(command.Role.Email),
                e => e.RegisteredAt.ShouldEqual(now)
            );

        It should_create_a_system_configurator_registered_event = () => {
            sut.ShouldHaveEvent<StaffDataConsumerRegistered>().InStream().Where(
                e => e.NationalSociety.ShouldEqual(command.Role.NationalSociety),
                e => e.PreferredLanguage.ShouldEqual((int)command.Role.PreferredLanguage),
                e => e.Sex.ShouldEqual(Constants.NOT_KNOWN),
                e => e.BirthYear.ShouldEqual(Constants.NOT_KNOWN),
                e => e.Latitude.ShouldEqual(constants.valid_location.Latitude),
                e => e.Longitude.ShouldEqual(constants.valid_location.Longitude)
            );
        };
    }    
}