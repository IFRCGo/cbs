using System;
using System.Collections.Generic;
using Concepts;
using Domain.DataCollector.Registering;

namespace Domain.Specs.DataCollector.when_updating_a_data_collector.given
{
    public class a_command_builder
    {
        public static RegisterDataCollector get_valid_command()
         {
             return new RegisterDataCollector()
             {
                 DataCollectorId = Guid.NewGuid(),
                 IsNewRegistration = false,
                 FullName = "Data Collector",
                 DisplayName = "Daty",
                 NationalSociety = Guid.NewGuid(),
                 PreferredLanguage = Language.English,
                 GpsLocation = new Location(123,123),
                 PhoneNumbers = new [] {"123456789"},
                 //Email = "test@test.com"
                 
             };
         }

         public static RegisterDataCollector get_invalid_command(IEnumerable<Action<RegisterDataCollector>> invalidations)
         {
             var cmd = get_valid_command();
             foreach(var invalidate in invalidations)
             {
                 invalidate(cmd);
             }
             return cmd;
         }


         public static RegisterDataCollector get_invalid_command(Action<RegisterDataCollector> invalidate)
         {
             return get_invalid_command(new []{ invalidate });
         }
    }
}