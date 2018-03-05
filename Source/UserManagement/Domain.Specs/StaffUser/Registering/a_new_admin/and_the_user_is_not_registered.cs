using Machine.Specifications;
using su = Domain.StaffUser;
using System;
using Events.StaffUser.Registration;


namespace Domain.Specs.StaffUser.Registering.a_new_admin
{
    [Subject("Registering")]
    public class and_the_user_is_not_registered
    {
        static su.StaffUser sut;
        static DateTimeOffset now;
        static string name;
        static string display_name;
        static string email;

        Establish context = () => 
        {
            now = DateTimeOffset.UtcNow;
            name = "name";
            display_name = "display";
            email = "test@redcross.com";
            sut = new su.StaffUser(Guid.NewGuid());
        };

        Because of = () => sut.RegisterNewAdminUser(name,display_name,email,now);

        It should_create_a_new_admin_user_registed_event_with_the_correct_values 
            = () => sut.ShouldHaveEvent<NewUserRegistered>().AtBeginning().Where(
                e => e.FullName.ShouldEqual(name),
                e => e.DisplayName.ShouldEqual(display_name),
                e => e.Email.ShouldEqual(email),
                e => e.RegisteredAt.ShouldEqual(now)
            );

    }
}