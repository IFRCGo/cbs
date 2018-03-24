using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Concepts;
using DnsClient;
using Domain.DataCollector.Registering;
using Domain.StaffUser.Registering;
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
            GenerateCorrectRegisterStaffUserCommands();
        }

        public static void GenerateCorrectRegisterDataCollectorCommands()
        {

            var data = new List<RegisterDataCollector>();

            foreach (var name in names)
            {
                var dataCollector = DataCollectorRegistrationGenerator.DefaultRegisterDataCollector();
                dataCollector.DisplayName = name + "_Disp";
                dataCollector.FullName = name;
                data.Add(dataCollector);
            }
            using (var file = File.CreateText("./TestData/DataCollectors.json"))
            {
                file.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));
            }
        }

        public static void GenerateCorrectRegisterStaffUserCommands()
        {
            const int numRegistrations = 100;

            var roleVals = Enum.GetValues(typeof(Role));
            var rng = new Random();
            var sb = new StringBuilder();

            var admins = new List<RegisterNewAdminUser>();
            var dataConsumers = new List<RegisterNewStaffDataConsumer>();
            var dataCoordinator = new List<RegisterNewDataCoordinator>();
            var dataOwners = new List<RegisterNewDataOwner>();
            var dataVerifiers = new List<RegisterNewStaffDataVerifier>();
            var systemConfigurators = new List<RegisterNewSystemConfigurator>();

            for (var i = 0; i < numRegistrations; i++)
            {  
                var role = (Role)roleVals.GetValue(rng.Next(roleVals.Length));

                switch (role)
                {
                    case Role.Admin:
                        admins.Add(StaffUserRegistrationGenerator.GenerateDefaultNewStaffRegistration<RegisterNewAdminUser>());
                        break;
                    case Role.DataConsumer:
                        dataConsumers.Add(StaffUserRegistrationGenerator.GenerateDefaultNewStaffRegistration<RegisterNewStaffDataConsumer>());
                        break;
                    case Role.DataCoordinator:
                        dataCoordinator.Add(StaffUserRegistrationGenerator.GenerateDefaultNewStaffRegistration<RegisterNewDataCoordinator>());
                        break;
                    case Role.DataOwner:
                        dataOwners.Add(StaffUserRegistrationGenerator.GenerateDefaultNewStaffRegistration<RegisterNewDataOwner>());
                        break;
                    case Role.DataVerifier:
                        dataVerifiers.Add(StaffUserRegistrationGenerator.GenerateDefaultNewStaffRegistration<RegisterNewStaffDataVerifier>());
                        break;
                    case Role.SystemCoordinator:
                        systemConfigurators.Add(StaffUserRegistrationGenerator.GenerateDefaultNewStaffRegistration<RegisterNewSystemConfigurator>());
                        break;
                }
            }
            using (var file = File.CreateText("./TestData/Admins.json"))
            {
                file.WriteLine(JsonConvert.SerializeObject(admins, Formatting.Indented));
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
    }
}
