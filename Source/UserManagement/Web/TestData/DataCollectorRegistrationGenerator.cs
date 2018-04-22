using System;
using System.Collections.Generic;
using Concepts;
using Domain.DataCollector.Registering;

namespace Web.TestData
{
    public class DataCollectorRegistrationGenerator
    {
        public static RegisterDataCollector DefaultRegisterDataCollector()
        {
            return new RegisterDataCollector
            {
                DataCollectorId = Guid.NewGuid(),
                IsNewRegistration = true,
                FullName = "Data Collector",
                DisplayName = "Daty",
                YearOfBirth = 1980,
                Sex = Sex.Male,
                PreferredLanguage = Language.English,
                GpsLocation = new Location(123, 123),
                PhoneNumbers = new List<string> { "123456789" },
                RegisteredAt = DateTimeOffset.UtcNow
            };
        }
    }
}