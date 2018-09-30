using System;
using System.Collections.Generic;
using Concepts;
using Domain.DataCollectors.Registering;

namespace Web.TestData
{
    public class DataCollectorRegistrationGenerator
    {
        public static RegisterDataCollector DefaultRegisterDataCollector()
        {
            return new RegisterDataCollector
            {
                DataCollectorId = Guid.NewGuid(),
                FullName = "Data Collector",
                DisplayName = "Daty",
                YearOfBirth = 1980,
                Sex = Sex.Male,
                PreferredLanguage = Language.English,
                GpsLocation = new Location(35, 35),
                PhoneNumbers = new List<string> { "123456789" },
                Region = "Default Region",
                District = "Default District"
            };
        }
    }
}