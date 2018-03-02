// using Machine.Specifications;
// using su = Domain.StaffUser;
// using System;

// namespace Domain.Specs.StaffUser.Registering.a_new_system_configurator
// {
//     [Subject("Registering")]
//     public class and_the_user_is_already_registered
//     {
//         static su.StaffUser sut;
//         static DateTimeOffset now;
//         static Domain.StaffUser.UserInfo basic;
//         static Exception result;

//         Establish context = () => 
//         {
//             now = DateTimeOffset.UtcNow;
//             basic = StaffUser.UserInfo.given.user_info.build_valid_instance();
//             sut = new su.StaffUser(basic.StaffUserId);

//             //register the user so that they are already registered
//             sut.RegisterNewSystemConfigurator(basic.FullName,basic.DisplayName,basic.Email,now);
//         };

//         Because of = () => result = Catch.Exception(() => sut.RegisterNewSystemConfigurator(basic.FullName,basic.DisplayName,basic.Email,now));

//         It should_throw_an_exception = () => result.ShouldNotBeNull();
//         It should_be_a_user_already_registered_exception = () => result.ShouldBeOfExactType<UserAlreadyRegistered>();
//     }
// }