// using System;
// using Concepts;
// using System.Collections.Generic;
// using Domain.DataCollector.UpdateDataCollector;

// namespace Domain.Specs.when_adding_a_data_collector.given
// {
//     public class a_command_builder
//     {
//         public static AddDataCollector get_valid_command()
//         {
//             return  new AddDataCollector
//             {
//                 //DataCollectorId = Guid.NewGuid(),
//                 FullName = "Data Collector",
//                 DisplayName = "Daty",
//                 YearOfBirth = 1980,
//                 Sex = Sex.Male,
//                 NationalSociety = Guid.NewGuid(),
//                 PreferredLanguage = Language.English,
//                 GpsLocation = new Location(123,123),
//                 PhoneNumbers = "123456789",
//                 Email = "test@test.com"
//             };
//         }

//         public static AddDataCollector get_invalid_command(IEnumerable<Action<AddDataCollector>> invalidations)
//         {
//             var cmd = a_command_builder.get_valid_command();
//             foreach(var invalidate in invalidations)
//             {
//                 invalidate(cmd);
//             }
//             return cmd;
//         }


//         public static AddDataCollector get_invalid_command(Action<AddDataCollector> invalidate)
//         {
//             return a_command_builder.get_invalid_command(new Action<AddDataCollector>[]{ invalidate });
//         }
//     }
// }

