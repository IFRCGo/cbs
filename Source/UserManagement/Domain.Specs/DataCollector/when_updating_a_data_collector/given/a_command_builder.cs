using System;
using System.Collections.Generic;
using Concepts;
using Domain.DataCollector.Update;

namespace Domain.Specs.DataCollector.when_updating_a_data_collector.given
{
    public class a_command_builder
    {
        public static UpdateDataCollector get_valid_command()
         {
             return  new UpdateDataCollector
             {
                 DataCollectorId = Guid.NewGuid(),
                 FullName = "Data Collector",
                 DisplayName = "Daty",
                 NationalSociety = Guid.NewGuid(),
                 PreferredLanguage = Language.English,
                 GpsLocation = new Location(123,123),
                 PhoneNumbersAdded = new string[] {"123456789"},
                 PhoneNumbersRemoved = new string[] {"987654321"},
                 Email = "test@test.com"

                 
             };
         }

         public static UpdateDataCollector get_invalid_command(IEnumerable<Action<UpdateDataCollector>> invalidations)
         {
             var cmd = get_valid_command();
             foreach(var invalidate in invalidations)
             {
                 invalidate(cmd);
             }
             return cmd;
         }


         public static UpdateDataCollector get_invalid_command(Action<UpdateDataCollector> invalidate)
         {
             return get_invalid_command(new Action<UpdateDataCollector>[]{ invalidate });
         }
    }
}