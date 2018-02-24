using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Concepts;
using Domain;
using Domain.DataCollectors.Commands;
using Newtonsoft.Json;

namespace Web.TestData
{
    public static class TestDataGenerator
    {
        private static readonly Random rng = new Random();
        private static readonly string[] _names =
        {
            "Abraham Watson", "Vanessa Wallace",
            "Billie Mclaughlin"
        };



        public static void GenerateAllTestData()
        {
            GenerateCorrectAddDataCollectorCommands();
        }

        public static void GenerateCorrectAddDataCollectorCommands()
        {
            var data = _names.Select(name => new AddDataCollector
                {
                    DisplayName = name.Replace(' ', '_') + "DISP",
                    Email = name.Replace(' ', '_') + "@mail.com",
                    FullName = name,
                    GpsLocation = new Location(rng.NextDouble(), rng.NextDouble()),
                    MobilePhoneNumber = rng.Next(00000000, 99999999).ToString(),
                    NationalSociety = Guid.NewGuid(),
                    PreferredLanguage = rng.Next(0, 2) < 1 ? Language.English : Language.French,
                    Sex = rng.Next(0, 2) < 1 ? Sex.Male : Sex.Female,
                    YearOfBirth = rng.Next(1900, 2018)
                })
                .ToList();


            using (var file = File.CreateText("./TestData/DataCollectors.json"))
            {
                file.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));   
            }
        }

        public static void GenerateStaffUsers()
        {
            var data = new List<AddStaffUser>();
            for (var i = 0; i < 100; i++)
            {
                data.Add(new AddStaffUser
                {
                    
                });
            }
        }
    }
}