// using Machine.Specifications;
// using su = Domain.StaffUser;
// using System;
// using System.Linq;
// using Events.StaffUser;


// namespace Domain.Specs.StaffUser.Registering.a_new_system_configurator
// {
//     [Subject("Registering")]
//     public class and_the_user_is_not_registered
//     {
//         static su.StaffUser sut;
//         static DateTimeOffset now;
//         static Domain.StaffUser.UserInfo basic;

//         Establish context = () => 
//         {
//             now = DateTimeOffset.UtcNow;
//             basic = StaffUser.UserInfo.given.user_info.build_valid_instance();
//             sut = new su.StaffUser(basic.StaffUserId);
//         };

//         Because of = () => sut.RegisterNewSystemConfigurator(basic.FullName,basic.DisplayName,basic.Email,now);

//         It should_create_a_new_admin_user_registed_event_with_the_correct_values 
//             = () => sut.ShouldHaveEvent<NewUserRegistered>().AtBeginning().Where(
//                 e => e.FullName.ShouldEqual(basic.FullName),
//                 e => e.DisplayName.ShouldEqual(basic.DisplayName),
//                 e => e.Email.ShouldEqual(basic.Email),
//                 e => e.RegisteredAt.ShouldEqual(now)
//             );

//     }
// }