using System;
using System.Collections.Generic;
using System.IO;
using Concepts;
using Domain.DataCollectors.Registration;
using Events.DataCollectors.Registration;
// using Domain.StaffUser.Registering;
using Newtonsoft.Json;

namespace Web.TestData
{
    public static class TestDataGenerator
    {
        private static readonly string[] names =
        {
            "Abraham Watson",
            "Vanessa Wallace",
            "Billie Mclaughlin"
        };

        public static void GenerateAllTestData()
        {
            GenerateCorrectRegisterDataCollectorCommands();
        }

        public static void GenerateCorrectRegisterDataCollectorCommands()
        {

            var data = new List<DataCollectorRegistered>();

            foreach (var name in names)
            {
                var dataCollector = DataCollectorRegistrationGenerator.DefaultRegisterDataCollector();
                data.Add(dataCollector);
            }
            using (var file = File.CreateText("./TestData/DataCollectors.json"))
            {
                file.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));
            }
        }
    }
}
