using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Web.TestData
{
    public static class TestDataGenerator
    {
        public static void GenerateAllTestData()
        {
            GenerateCorrectRegisterDataCollectorCommands();
            GenerateCorrectRegisterStaffUserCommands();
        }

        public static void GenerateCorrectRegisterDataCollectorCommands()
        {
           
            //var data = new List<RegisterDataCollector>();

            //foreach (var name in names)
            //{
            //    var dataCollector = specs.DataCollector.when_registering_a_data_collector.given.a_command_builder.get_valid_command();
            //    dataCollector.DisplayName = name + "_Disp";
            //    dataCollector.FullName = name;
            //    data.Add(dataCollector);
            //}
            //using (var file = File.CreateText("./TestData/DataCollectors.json"))
            //{
            //    file.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));   
            //}
        }

        public static void GenerateCorrectRegisterStaffUserCommands()
        {
            //StringBuilder sb = new StringBuilder();
            //const int numRegistrations = 100;

            //var roleVals = Enum.GetValues(typeof(_Role));
            
            //var admins = new List<RegisterNewAdminUser>();
            //var dataConsumers = new List<RegisterNewStaffDataConsumer>();
            //var dataCoordinator = new List<RegisterNewDataCoordinator>();
            //var dataOwners = new List<RegisterNewDataOwner>();
            //var dataVerifiers = new List<RegisterNewStaffDataVerifier>();
            //var systemConfigurators = new List<RegisterNewSystemConfigurator>();


            //for (var i = 0; i < numRegistrations; i++)
            //{
            //    //TODO: Should we depend on _Role? 
            //    //TODO: Maybe create another class to create commands dynamically, like in Domain.Specs
            //    _Role role = (_Role)roleVals.GetValue(rng.Next(roleVals.Length));

            //    switch (role)
            //    {
            //        case _Role.Admin:
            //            admins.Add(specs.StaffUser.Registering.given.commands.build_valid_instance<RegisterNewAdminUser>());
            //            break;
            //        case _Role.DataConsumer:
            //            dataConsumers.Add(specs.StaffUser.Registering.given.commands.build_valid_instance<RegisterNewStaffDataConsumer>());
            //            break;
            //        case _Role.DataCoordinator:
            //            dataCoordinator.Add(specs.StaffUser.Registering.given.commands.build_valid_instance<RegisterNewDataCoordinator>());
            //            break;
            //        case _Role.DataOwner:
            //            dataOwners.Add(specs.StaffUser.Registering.given.commands.build_valid_instance<RegisterNewDataOwner>());
            //            break;
            //        case _Role.DataVerifier:
            //            dataVerifiers.Add(specs.StaffUser.Registering.given.commands.build_valid_instance<RegisterNewStaffDataVerifier>());
            //            break;
            //        case _Role.SystemCoordinator:
            //            systemConfigurators.Add(specs.StaffUser.Registering.given.commands.build_valid_instance<RegisterNewSystemConfigurator>());
            //            break;
            //    }
            //}
            //using (var file = File.CreateText("./TestData/Admins.json"))
            //{
            //    file.WriteLine(JsonConvert.SerializeObject(admins, Formatting.Indented ));
            //}
            //using (var file = File.CreateText("./TestData/DataConsumers.json"))
            //{
            //    file.WriteLine(JsonConvert.SerializeObject(dataConsumers, Formatting.Indented));
            //}
            //using (var file = File.CreateText("./TestData/DataCoordinators.json"))
            //{
            //    file.WriteLine(JsonConvert.SerializeObject(dataCoordinator, Formatting.Indented));
            //}
            //using (var file = File.CreateText("./TestData/DataOwners.json"))
            //{
            //    file.WriteLine(JsonConvert.SerializeObject(dataOwners, Formatting.Indented));
            //}
            //using (var file = File.CreateText("./TestData/DataVerifiers.json"))
            //{
            //    file.WriteLine(JsonConvert.SerializeObject(dataVerifiers, Formatting.Indented));
            //}
            //using (var file = File.CreateText("./TestData/SystemConfigurators.json"))
            //{
            //    file.WriteLine(JsonConvert.SerializeObject(systemConfigurators, Formatting.Indented));
            //}
        }
    }
}
