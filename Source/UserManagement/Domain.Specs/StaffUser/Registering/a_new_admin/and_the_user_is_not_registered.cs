using Machine.Specifications;
using su = Domain.StaffUser;
using System;
using System.Linq;
using Events.StaffUser;

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

        It should_generate_a_new_admin_user_registered_event 
            = () => sut.UncommittedEvents.First().ShouldBeOfExactType<NewAdminUserRegistered>();
        It should_have_the_correct_full_name = () => get_event().FullName.ShouldEqual(name);
        It should_have_the_correct_display_name = () => get_event().DisplayName.ShouldEqual(display_name);
        It should_have_the_correct_email = () => get_event().Email.ShouldEqual(email);
        It should_have_the_correct_registed_at_time = () => get_event().RegisteredAt.ShouldEqual(now);

        static NewAdminUserRegistered get_event()
        {
            return sut.UncommittedEvents.First() as NewAdminUserRegistered;
        }
    }
}