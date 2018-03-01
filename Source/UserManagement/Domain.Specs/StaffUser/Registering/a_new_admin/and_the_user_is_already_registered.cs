using Machine.Specifications;
using su = Domain.StaffUser;
using System;

namespace Domain.Specs.StaffUser.Registering.a_new_admin
{
    [Subject("Registering")]
    public class and_the_user_is_already_registered
    {
        static su.StaffUser sut;
        static DateTimeOffset now;
        static string name;
        static string display_name;
        static string email;
        static Exception result;

        Establish context = () => 
        {
            now = DateTimeOffset.UtcNow;
            name = "name";
            display_name = "display";
            email = "test@redcross.com";
            sut = new su.StaffUser(Guid.NewGuid());

            //register the user so that they are already registered
            sut.RegisterNewAdminUser(name,display_name,email,now);
        };

        Because of = () => result = Catch.Exception(() => sut.RegisterNewAdminUser(name,display_name,email,now));

        It should_throw_an_exception = () => result.ShouldNotBeNull();
        It should_be_a_user_already_registered_exception = () => result.ShouldBeOfExactType<UserAlreadyRegistered>();
    }
}