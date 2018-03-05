using System;
using Concepts;
using Domain.Specs.StaffUser.Roles.UserInfo.given;
using Domain.StaffUser.Registering;
using Domain.StaffUser.Roles;
using Events.StaffUser;
using Events.StaffUser.Registration;
using Machine.Specifications;


using su = Domain.StaffUser;
namespace Domain.Specs.StaffUser.Registering.a_new_system_configurator
{

    [Subject("Registering")]
    public class and_the_user_is_not_registered_and_there_are_no_optional_values
    {
        //TODO: Does not compile
        static su.StaffUser sut;
        static DateTimeOffset now;
        static RegisterNewSystemConfigurator cmd;
        static SystemConfigurator role;

        private Establish context = () =>
        {
            now = DateTimeOffset.UtcNow;
            cmd = given.commands.build_valid_instance<RegisterNewSystemConfigurator>();
            role = cmd.Role;

            sut = new su.StaffUser(role.StaffUserId);
            
        };

        Because of = () =>
        {
            sut.RegisterNewSystemConfigurator(role.FullName, role.DisplayName, role.Email, now,
                    role.NationalSociety, role.PreferredLanguage.Value, role.PhoneNumbers, role.AssignedNationalSocieties,
                    role.BirthYear, role.Sex);
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
            sut.ShouldHaveEvent<SystemConfiguratorRegistered>().InStream().Where(
                e => e.NationalSociety.ShouldEqual(role.NationalSociety),
                e => e.PreferredLanguage.ShouldEqual((int)role.PreferredLanguage),
                //TODO: Michael will this be correct?
                e => e.Sex.ShouldEqual(Constants.NOT_KNOWN),
                e => e.BirthYear.ShouldEqual(Constants.NOT_KNOWN)
            );
        };

        It should_create_a_national_society_assigned_for_each_national_society = () =>
        {
            sut.ShouldHaveEvent<NationalSocietyAssigned>().Instances(2);
        };

        It should_create_a_phone_number_registered_event_for_each_phone_number = () =>
        {
            sut.ShouldHaveEvent<PhoneNumberRegistered>().Instances(2);
        };
    }    
}