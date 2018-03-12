using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Concepts;
using Domain.DataCollector.Registering;
using Domain.StaffUser.Registering;
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
        private static int numSystemConfigurators = 0;

        private static Array languageVals = Enum.GetValues(typeof(Language));
        private static Array sexVals = Enum.GetValues(typeof(Sex));

        private static readonly Random rng = new Random();

        private static readonly string[] names =
        {
            "Abraham Watson",
            "Vanessa Wallace",
            "Billie Mclaughlin"
        };

        private static readonly Guid[] nationalSocieties =
            Enumerable.Range(0, 10).Select(x => Guid.NewGuid()).ToArray();


        public static void GenerateAllTestData()
        {
            GenerateCorrectRegisterDataCollectorCommands();
            GenerateCorrectRegisterStaffUserCommands();
        }

        public static void GenerateCorrectRegisterDataCollectorCommands()
        {
            var data = names.Select(name => new RegisterDataCollector
                {
                    DisplayName = name.Replace(' ', '_') + "DISP",
                    FullName = name,
                    GpsLocation = new Location(rng.NextDouble(), rng.NextDouble()),
                    PhoneNumbers = new List<string> {rng.Next(00000000, 99999999).ToString()},
                    NationalSociety = Guid.NewGuid(),
                    PreferredLanguage = (Language)languageVals.GetValue(rng.Next(languageVals.Length)),
                    Sex = (Sex)sexVals.GetValue(rng.Next(sexVals.Length)),
                    YearOfBirth = rng.Next(1920, 2018)
                }).ToList();


            using (var file = File.CreateText("./TestData/DataCollectors.json"))
            {
                file.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));   
            }
        }

        public static void GenerateCorrectRegisterStaffUserCommands()
        {
            StringBuilder sb = new StringBuilder();
            const int numRegistrations = 100;

            var roleVals = Enum.GetValues(typeof(_Role));


            List<RegisterNewAdminUser> admins = new List<RegisterNewAdminUser>();
            List<RegisterNewStaffDataConsumer> dataConsumers = new List<RegisterNewStaffDataConsumer>();
            List<RegisterNewDataCoordinator> dataCoordinator = new List<RegisterNewDataCoordinator>();
            List<RegisterNewDataOwner> dataOwners = new List<RegisterNewDataOwner>();
            List<RegisterNewStaffDataVerifier> dataVerifiers = new List<RegisterNewStaffDataVerifier>();
            List<RegisterNewSystemConfigurator> systemConfigurators = new List<RegisterNewSystemConfigurator>();


            for (var i = 0; i < numRegistrations; i++)
            {
                //TODO: Should we depend on _Role? 
                //TODO: Maybe create another class to create commands dynamically, like in Domain.Specs
                _Role role = (_Role)roleVals.GetValue(rng.Next(roleVals.Length));

                switch (role)
                {
                    case _Role.Admin:
                        admins.Add(CreateRegisterNewAdminUserCommand());
                        break;
                    case _Role.DataConsumer:
                        dataConsumers.Add(CreateRegisterNewDataConsumerCommand());
                        break;
                    case _Role.DataCoordinator:
                        dataCoordinator.Add(CreateRegisterNewDataCoordinatorCommand());
                        break;
                    case _Role.DataOwner:
                        dataOwners.Add(CreateRegisterNewDataOwnerCommand());
                        break;
                    case _Role.DataVerifier:
                        dataVerifiers.Add(CreateRegisterNewStaffDataVerifierCommand());
                        break;
                    case _Role.SystemCoordinator:
                        systemConfigurators.Add(CreateRegisterNewSystemConfiguratorCommand());
                        break;
                }
            }
            using (var file = File.CreateText("./TestData/Admins.json"))
            {
                file.WriteLine(JsonConvert.SerializeObject(admins, Formatting.Indented ));
            }
            using (var file = File.CreateText("./TestData/DataConsumers.json"))
            {
                file.WriteLine(JsonConvert.SerializeObject(dataConsumers, Formatting.Indented));
            }
            using (var file = File.CreateText("./TestData/DataCoordinators.json"))
            {
                file.WriteLine(JsonConvert.SerializeObject(dataCoordinator, Formatting.Indented));
            }
            using (var file = File.CreateText("./TestData/DataOwners.json"))
            {
                file.WriteLine(JsonConvert.SerializeObject(dataOwners, Formatting.Indented));
            }
            using (var file = File.CreateText("./TestData/DataVerifiers.json"))
            {
                file.WriteLine(JsonConvert.SerializeObject(dataVerifiers, Formatting.Indented));
            }
            using (var file = File.CreateText("./TestData/SystemConfigurators.json"))
            {
                file.WriteLine(JsonConvert.SerializeObject(systemConfigurators, Formatting.Indented));
            }

        }
        private static RegisterNewAdminUser CreateRegisterNewAdminUserCommand()
        {
            var name = "Admin" + numAdmins;
            var result = new RegisterNewAdminUser()
            {
                Role =
                {
                    FullName = name,
                    DisplayName = name + "_Display_Name",
                    Email = name + "@mail.com",
                }
            };
            numAdmins++;

            return result;
        }
        private static RegisterNewStaffDataConsumer CreateRegisterNewDataConsumerCommand()
        {
            var name = "DataConsumer" + numDataConsumers;
            var result = new RegisterNewStaffDataConsumer
            {
                Role =
                {
                    FullName = name,
                    DisplayName = name + " Display name",
                    Email = name + "@mail.com",

                    Location = new Location(rng.NextDouble(), rng.NextDouble()),
                    BirthYear = rng.Next(1920, 2017),
                    NationalSociety = nationalSocieties[rng.Next(nationalSocieties.Length)],
                    PreferredLanguage = (Language)languageVals.GetValue(rng.Next(languageVals.Length)),
                    Sex = (rng.NextDouble() < 0.8)? (Sex)sexVals.GetValue(rng.Next(sexVals.Length)) : (Sex?)null,
                    StaffUserId = Guid.NewGuid()
                }
            };
            numDataConsumers++;

            return result;
        }
        private static RegisterNewDataCoordinator CreateRegisterNewDataCoordinatorCommand()
        {
            var name = "DataCoordinator" + numDataCoordinators;
            var result = new RegisterNewDataCoordinator()
            {
                Role =
                {
                    FullName = name,
                    DisplayName = name + " Display name",
                    Email = name + "@mail.com",
                    
                    BirthYear = rng.Next(1920, 2017),
                    
                    NationalSociety = nationalSocieties[rng.Next(nationalSocieties.Length)],
                    PreferredLanguage = (Language)languageVals.GetValue(rng.Next(languageVals.Length)),
                    Sex = (rng.NextDouble() < 0.8)? (Sex)sexVals.GetValue(rng.Next(sexVals.Length)) : (Sex?)null,
                    StaffUserId = Guid.NewGuid(),
                    PhoneNumbers = new List<string> { rng.Next(00000000, 99999999).ToString() },
                    AssignedNationalSocieties = new List<Guid> { nationalSocieties[rng.Next(nationalSocieties.Length)] }
                }
            };
            numDataCoordinators++;

            return result;
        }
        private static RegisterNewDataOwner CreateRegisterNewDataOwnerCommand()
        {
            var name = "DataOwner" + numDataOwners;
            
            var result = new RegisterNewDataOwner()
            {
                Role = {
                    FullName = name,
                    DisplayName = name + " Display name",
                    Email = name + "@mail.com",

                    BirthYear = rng.Next(1920, 2017),

                    NationalSociety = nationalSocieties[rng.Next(nationalSocieties.Length)],
                    PreferredLanguage = (Language)languageVals.GetValue(rng.Next(languageVals.Length)),
                    Sex = (rng.NextDouble() < 0.8)? (Sex)sexVals.GetValue(rng.Next(sexVals.Length)) : (Sex?)null,
                    StaffUserId = Guid.NewGuid(),
                    PhoneNumbers = new List<string> { rng.Next(00000000, 99999999).ToString() },
                    AssignedNationalSocieties = new List<Guid> { nationalSocieties[rng.Next(nationalSocieties.Length)] },
                    Location = new Location(rng.NextDouble(), rng.NextDouble()),
                    DutyStation = "Dutty Station" + numDataOwners,
                    Position = "Position" + numDataOwners
                }
            };
            numDataOwners++;

            return result;
        }
        private static RegisterNewStaffDataVerifier CreateRegisterNewStaffDataVerifierCommand()
        {
            var name = "DataVerifier" + numDataVerifiers;

            var result = new RegisterNewStaffDataVerifier()
            {
                Role =
                {
                    FullName = name,
                    DisplayName = name + " Display name",
                    Email = name + "@mail.com",

                    BirthYear = rng.Next(1920, 2017),

                    NationalSociety = nationalSocieties[rng.Next(nationalSocieties.Length)],
                    PreferredLanguage = (Language)languageVals.GetValue(rng.Next(languageVals.Length)),
                    Sex = (rng.NextDouble() < 0.8)? (Sex)sexVals.GetValue(rng.Next(sexVals.Length)) : (Sex?)null,
                    StaffUserId = Guid.NewGuid(),
                    PhoneNumbers = new List<string> { rng.Next(00000000, 99999999).ToString() },
                    AssignedNationalSocieties = new List<Guid> { nationalSocieties[rng.Next(nationalSocieties.Length)] },
                    Location = new Location(rng.NextDouble(), rng.NextDouble())
                }
            };
            numDataVerifiers++;

            return result;
        }
        private static RegisterNewSystemConfigurator CreateRegisterNewSystemConfiguratorCommand()
        {
            var name = "SystemConfigurator" + numSystemConfigurators;
            var result = new RegisterNewSystemConfigurator()
            {
                Role =
                {
                    FullName = name,
                    DisplayName = name + " Display name",
                    Email = name + "@mail.com",

                    BirthYear = rng.Next(1920, 2017),

                    NationalSociety = nationalSocieties[rng.Next(nationalSocieties.Length)],
                    PreferredLanguage = (Language)languageVals.GetValue(rng.Next(languageVals.Length)),
                    Sex = (rng.NextDouble() < 0.8)? (Sex)sexVals.GetValue(rng.Next(sexVals.Length)) : (Sex?)null,
                    StaffUserId = Guid.NewGuid(),
                    PhoneNumbers = new List<string> { rng.Next(00000000, 99999999).ToString() },
                    AssignedNationalSocieties = new List<Guid> { nationalSocieties[rng.Next(nationalSocieties.Length)] }
                }
            };
            numSystemConfigurators++;

            return result;
        }
    }
}
