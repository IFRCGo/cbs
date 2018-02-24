using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Concepts;
using Domain.DataCollectors.Commands;
using Domain.StaffUser.Commands;
using Newtonsoft.Json;

namespace Web.TestData
{
    public static class TestDataGenerator
    {
        private static int numAdmins = 0;
        private static int numDataConsumers = 0;
        private static int numDataCoordinators = 0;
        private static int numDataOwners = 0;
        private static int numDataVerifiers = 0;
        private static int numSystemCoordinators = 0;

        private static readonly Random rng = new Random();
        private static readonly string[] names =
        {
            "Abraham Watson", "Vanessa Wallace",
            "Billie Mclaughlin"
        };

        private static readonly Guid[] nationalSocieties =
        {
            Guid.NewGuid(), Guid.NewGuid(),
            Guid.NewGuid(), Guid.NewGuid()
        };


        public static void GenerateAllTestData()
        {
            GenerateCorrectAddDataCollectorCommands();
            GenerateCorrectAddStaffUserCommands();
        }

        public static void GenerateCorrectAddDataCollectorCommands()
        {
            var data = names.Select(name => new AddDataCollector
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

        public static void GenerateCorrectAddStaffUserCommands()
        {
            var data = new List<AddStaffUser>();
            for (var i = 0; i < 100; i++)
            {
                Role role = (Role)rng.Next(0, 6);

                switch (role)
                {
                    case Role.Admin:
                        data.Add(CreateAddAdminCommand());
                        break;
                    case Role.DataConsumer:
                        data.Add(CreateAddDataConsumerCommand());
                        break;
                    case Role.DataCoordinator:
                        data.Add(CreateAddDataCoordinatorCommand());
                        break;
                    case Role.DataOwner:
                        data.Add(CreateAddDataOwnerCommand());
                        break;
                    case Role.DataVerifier:
                        data.Add(CreateAddDataVerifierCommand());
                        break;
                    case Role.SystemCoordinator:
                        data.Add(CreateAddSystemCoordinatorCommand());
                        break;
                }
            }
            using (var file = File.CreateText("./TestData/StaffUsers.json"))
            {
                file.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));
            }

        }
        private static AddStaffUser CreateAddAdminCommand()
        {
            var name = "Admin" + numAdmins;
            var result = new AddStaffUser
            {
                Role = Role.Admin,
                FullName = name,
                DisplayName = name + " Display name",
                Email = name + "@mail.com"
            };
            numAdmins++;

            return result;
        }
        private static AddStaffUser CreateAddDataConsumerCommand()
        {
            var name = "DataConsumer" + numDataConsumers;
            var result = new AddStaffUser
            {
                Role = Role.DataConsumer,
                FullName = name,
                DisplayName = name + " Display name",
                Email = name + "@mail.com",

                Location = new Location(rng.NextDouble(), rng.NextDouble())
            };
            numDataConsumers++;

            return result;
        }
        private static AddStaffUser CreateAddDataCoordinatorCommand()
        {
            var name = "DataCoordinator" + numDataCoordinators;
            var result = new AddStaffUser
            {
                Role = Role.DataCoordinator,
                FullName = name,
                DisplayName = name + " Display name",
                Email = name + "@mail.com",

                YearOfBirth = rng.Next(1900, 2018),
                Sex = rng.Next(0, 2) < 1? Sex.Male : Sex.Female,
                NationalSociety = nationalSocieties[rng.Next(nationalSocieties.Length)],
                PreferredLanguage = rng.Next(0, 2) < 1 ? Language.English : Language.French,
                Location = new Location(rng.NextDouble(), rng.NextDouble()),
                MobilePhoneNumber = rng.Next(00000000, 99999999).ToString(),
                AssignedNationalSociety = nationalSocieties[rng.Next(nationalSocieties.Length)]
            };
            numDataCoordinators++;

            return result;
        }
        private static AddStaffUser CreateAddDataOwnerCommand()
        {
            var name = "DataOwner" + numDataOwners;
            var result = new AddStaffUser
            {
                Role = Role.DataOwner,
                FullName = name,
                DisplayName = name + " Display name",
                Email = name + "@mail.com",

                YearOfBirth = rng.Next(1900, 2018),
                Sex = rng.Next(0, 2) < 1 ? Sex.Male : Sex.Female,
                NationalSociety = nationalSocieties[rng.Next(nationalSocieties.Length)],
                PreferredLanguage = rng.Next(0, 2) < 1 ? Language.English : Language.French,
                Location = new Location(rng.NextDouble(), rng.NextDouble()),
                MobilePhoneNumber = rng.Next(00000000, 99999999).ToString(),
                AssignedNationalSociety = nationalSocieties[rng.Next(nationalSocieties.Length)],
                DutyStation = "Duty Station" + numDataOwners,
                Position = "Position" + numDataOwners
            };
            numDataOwners++;

            return result;
        }
        private static AddStaffUser CreateAddDataVerifierCommand()
        {
            var name = "DataVerifier" + numDataVerifiers;
            var result = new AddStaffUser
            {
                Role = Role.DataVerifier,
                FullName = name,
                DisplayName = name + " Display name",
                Email = name + "@mail.com",

                YearOfBirth = rng.Next(1900, 2018),
                Sex = rng.Next(0, 2) < 1 ? Sex.Male : Sex.Female,
                NationalSociety = nationalSocieties[rng.Next(nationalSocieties.Length)],
                PreferredLanguage = rng.Next(0, 2) < 1 ? Language.English : Language.French,
                Location = new Location(rng.NextDouble(), rng.NextDouble()),
                MobilePhoneNumber = rng.Next(00000000, 99999999).ToString(),
                AssignedNationalSociety = nationalSocieties[rng.Next(nationalSocieties.Length)]
            };
            numDataVerifiers++;

            return result;
        }
        private static AddStaffUser CreateAddSystemCoordinatorCommand()
        {
            var name = "SystemCoordinator" + numSystemCoordinators;
            var result = new AddStaffUser
            {
                Role = Role.SystemCoordinator,
                FullName = name,
                DisplayName = name + " Display name",
                Email = name + "@mail.com",

                YearOfBirth = rng.Next(1900, 2018),
                Sex = rng.Next(0, 2) < 1 ? Sex.Male : Sex.Female,
                NationalSociety = nationalSocieties[rng.Next(nationalSocieties.Length)],
                PreferredLanguage = rng.Next(0, 2) < 1 ? Language.English : Language.French,
                Location = new Location(rng.NextDouble(), rng.NextDouble()),
                MobilePhoneNumber = rng.Next(00000000, 99999999).ToString(),
                AssignedNationalSociety = nationalSocieties[rng.Next(nationalSocieties.Length)]
            };
            numSystemCoordinators++;

            return result;
        }
    }
}