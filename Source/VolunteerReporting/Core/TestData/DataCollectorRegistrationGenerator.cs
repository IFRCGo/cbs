using System;
using System.Collections.Generic;
using Concepts.DataCollector;
using Domain.DataCollectors.Registration;
using Events.DataCollectors.Registration;

namespace Web.TestData
{
    public class DataCollectorRegistrationGenerator
    {
        public static DataCollectorRegistered DefaultRegisterDataCollector()
        {
            return new DataCollectorRegistered(
                Guid.NewGuid(), 
                "DataCollector",
                "Daty",
                1980,
                (int)Sex.Male,
                (int)Language.English,
                35, 35,
                DateTimeOffset.Now,
                "Default Region",
                "Default District");
        }
    }
}