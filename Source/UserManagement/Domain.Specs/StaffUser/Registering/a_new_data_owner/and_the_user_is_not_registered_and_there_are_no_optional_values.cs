using Machine.Specifications;
using su = Domain.StaffUser;
using System;
using System.Collections.Generic;
using System.Linq;
using Events.StaffUser;
using Concepts;
using Domain.StaffUser.Registering;
using Domain.StaffUser.Roles;

namespace Domain.Specs.StaffUser.Registering.a_new_data_owner
{
    [Subject("Registering")]
    public class and_the_user_is_not_registered_and_there_are_no_optional_values
    {
        static su.StaffUser sut;
        static DateTimeOffset now;
        static RegisterNewDataOwner cmd;
        static DataOwner role;

        private Establish context = () =>
        {
            now = DateTimeOffset.UtcNow;
            cmd = given.commands.build_valid_instance<RegisterNewDataOwner>();
            sut = new su.StaffUser(cmd.Role.StaffUserId);
            role = cmd.Role;
            role.BirthYear = null;
            role.PreferredLanguage = null;
            role.Sex = null;
        };

        Because of = () =>
        {
            sut.RegisterNewDataOwner(role.FullName, role.DisplayName, role.Email,
                now, role.NationalSociety, role.PreferredLanguage.Value, role.PhoneNumbers, role.BirthYear,
                role.Sex, role.Location, role.Position, role.DutyStation);
        };
        It should_create_a_new_user_registed_event_with_the_correct_values
            = () => sut.ShouldHaveEvent<NewUserRegistered>().AtBeginning().Where(
                e => e.FullName.ShouldEqual(role.FullName),
                e => e.DisplayName.ShouldEqual(role.DisplayName),
                e => e.Email.ShouldEqual(role.Email),
                e => e.RegisteredAt.ShouldEqual(now)
            );

        It should_create_a_system_configurator_registered_event = () =>
        {
            sut.ShouldHaveEvent<DataOwnerRegistered>().InStream().Where(
                e => e.Position.ShouldEqual(constants.valid_position),
                e => e.DutyStation.ShouldEqual(constants.valid_duty_station),
                e => e.Latitude.ShouldEqual(constants.valid_location.Latitude),
                e => e.Longitude.ShouldEqual(constants.valid_location.Longitude)
            );
        };
    }
}