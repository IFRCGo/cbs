using System;
using System.IO;
using Domain.DataCollector.Registering;
using Domain.StaffUser.Registering;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using Read.DataCollectors;
using Read.GreetingGenerators;
using Read.StaffUsers;
using Web.TestData;
using Dolittle.Commands.Coordination;
using Read.StaffUsers.Models;


namespace Web.Controllers
{
    [Route("api/testdatagenerator")]
    public class TestDataGeneratorController : Controller
    {
        private readonly IMongoDatabase _database;
        private readonly ICommandCoordinator _commandCoordinator;
        

        public TestDataGeneratorController(
            IMongoDatabase database,
            ICommandCoordinator commandCoordinator,
            
            IStaffUsers staffUsers
        )
        {
            _database = database;
            _commandCoordinator = commandCoordinator;
        }

        [HttpGet("generatetestdataset")]
        public void GenerateTestDataSet()
        {
            TestDataGenerator.GenerateAllTestData();
        }

        [HttpGet("all")]
        public void CreateAll()
        {
             CreateDataCollectorCommands();
             CreateAllStaffUserCommands();
        }
        
        [HttpGet("datacollectorcommands")]
        public void CreateDataCollectorCommands()
        {
            DeleteDataCollectors();
            RegisterDataCollector[] commands;
            try
            {
                commands = JsonConvert.DeserializeObject<RegisterDataCollector[]>(
                        System.IO.File.ReadAllText("./TestData/DataCollectors.json"));
            }
            catch (FileNotFoundException)
            {
                TestDataGenerator.GenerateCorrectRegisterDataCollectorCommands();
                commands = JsonConvert.DeserializeObject<RegisterDataCollector[]>(
                    System.IO.File.ReadAllText("./TestData/DataCollectors.json"));
            }

            foreach (var cmd in commands)
            {
                cmd.DataCollectorId = Guid.NewGuid();
                var result = _commandCoordinator.Handle(cmd);
            }

        }

        [HttpGet("allstaffusercommands")]
        public void CreateAllStaffUserCommands()
        {
            DeleteAllStaffUserCollections();

            CreateAllAdminUserCommands();
            CreateAllDataConsumerCommands();
            CreateAllDataCoordinatorCommands();
            CreateAllDataOwnerCommands();
            CreateAllDataVerifierCommands();
            CreateAllSystemConfiguratorCommands();
        }

        [HttpGet("alladminusercommands")]
        public void CreateAllAdminUserCommands()
        {
            DeleteAllAdmins();
            RegisterNewAdminUser[] commands;
            try
            {
                commands = JsonConvert.DeserializeObject<RegisterNewAdminUser[]>(
                    System.IO.File.ReadAllText("./TestData/Admins.json"));
            }
            catch (FileNotFoundException)
            {
                TestDataGenerator.GenerateCorrectRegisterStaffUserCommands();
                commands = JsonConvert.DeserializeObject<RegisterNewAdminUser[]>(
                    System.IO.File.ReadAllText("./TestData/Admins.json"));
            }

            foreach (var cmd in commands)
            {
                cmd.Role.StaffUserId = Guid.NewGuid();
                _commandCoordinator.Handle(cmd);
            }
        }
        [HttpGet("alldataconsumercommands")]
        public void CreateAllDataConsumerCommands()
        {
            RegisterNewStaffDataConsumer[] commands;
            try
            {
                commands = JsonConvert.DeserializeObject<RegisterNewStaffDataConsumer[]>(
                    System.IO.File.ReadAllText("./TestData/DataConsumers.json"));
            }
            catch (FileNotFoundException)
            {
                TestDataGenerator.GenerateCorrectRegisterStaffUserCommands();
                commands = JsonConvert.DeserializeObject<RegisterNewStaffDataConsumer[]>(
                    System.IO.File.ReadAllText("./TestData/DataConsumers.json"));
            }

            foreach (var cmd in commands)
            {
                cmd.Role.StaffUserId = Guid.NewGuid();
                _commandCoordinator.Handle(cmd);
            }
        }
        [HttpGet("alldatacoordinatorcommands")]
        public void CreateAllDataCoordinatorCommands()
        {
            RegisterNewDataCoordinator[] commands;
            try
            {
                commands = JsonConvert.DeserializeObject<RegisterNewDataCoordinator[]>(
                    System.IO.File.ReadAllText("./TestData/DataCoordinators.json"));
            }
            catch (FileNotFoundException)
            {
                TestDataGenerator.GenerateCorrectRegisterStaffUserCommands();
                commands = JsonConvert.DeserializeObject<RegisterNewDataCoordinator[]>(
                    System.IO.File.ReadAllText("./TestData/DataCoordinators.json"));
            }

            foreach (var cmd in commands)
            {
                cmd.Role.StaffUserId = Guid.NewGuid();
                _commandCoordinator.Handle(cmd);
            }
        }
        [HttpGet("alldataownercommands")]
        public void CreateAllDataOwnerCommands()
        {
            RegisterNewDataOwner[] commands;
            try
            {
                commands = JsonConvert.DeserializeObject<RegisterNewDataOwner[]>(
                    System.IO.File.ReadAllText("./TestData/DataOwners.json"));
            }
            catch (FileNotFoundException)
            {
                TestDataGenerator.GenerateCorrectRegisterStaffUserCommands();
                commands = JsonConvert.DeserializeObject<RegisterNewDataOwner[]>(
                    System.IO.File.ReadAllText("./TestData/DataOwners.json"));
            }

            foreach (var cmd in commands)
            {
                cmd.Role.StaffUserId = Guid.NewGuid();
                _commandCoordinator.Handle(cmd);
            }
        }
        [HttpGet("alldataverifiercommands")]
        public void CreateAllDataVerifierCommands()
        {
            RegisterNewStaffDataVerifier[] commands;
            try
            {
                commands = JsonConvert.DeserializeObject<RegisterNewStaffDataVerifier[]>(
                    System.IO.File.ReadAllText("./TestData/DataVerifiers.json"));
            }
            catch (FileNotFoundException)
            {
                TestDataGenerator.GenerateCorrectRegisterStaffUserCommands();
                commands = JsonConvert.DeserializeObject<RegisterNewStaffDataVerifier[]>(
                    System.IO.File.ReadAllText("./TestData/DataVerifiers.json"));
            }

            foreach (var cmd in commands)
            {
                cmd.Role.StaffUserId = Guid.NewGuid();
                _commandCoordinator.Handle(cmd);
            }
        }
        [HttpGet("allsystemconfiguratorcommands")]
        public void CreateAllSystemConfiguratorCommands()
        {
            RegisterNewSystemConfigurator[] commands;
            try
            {
                commands = JsonConvert.DeserializeObject<RegisterNewSystemConfigurator[]>(
                    System.IO.File.ReadAllText("./TestData/SystemConfigurators.json"));
            }
            catch (FileNotFoundException)
            {
                TestDataGenerator.GenerateCorrectRegisterStaffUserCommands();
                commands = JsonConvert.DeserializeObject<RegisterNewSystemConfigurator[]>(
                    System.IO.File.ReadAllText("./TestData/SystemConfigurators.json"));
            }

            foreach (var cmd in commands)
            {
                cmd.Role.StaffUserId = Guid.NewGuid();
                _commandCoordinator.Handle(cmd);
            }
        }

        #region Delete collections

        [HttpGet("deleteall")]
        public void DeleteAll()
        {
            DeleteAllStaffUserCollections();
            DeleteDataCollectors();
            DeleteGreetingHistory();
        }

        private void DeleteCollection<T>(string collectionName)
        {
            _database.GetCollection<T>(collectionName).DeleteMany(_ => true);
        }

        #region StaffUser

        [HttpGet("deleteallstaffusercollections")]
        public void DeleteAllStaffUserCollections()
        {
            DeleteCollection<BaseUser>("StaffUsers");
        }
        
        [HttpGet("deletealladmins")]
        public void DeleteAllAdmins()
        {
            var filter = Builders<BaseUser>.Filter.OfType<Admin>();
            _database.GetCollection<BaseUser>("StaffUser").DeleteMany(filter);
        }

        [HttpGet("deletealldataconsumers")]
        public void DeleteAllDataConsumers()
        {
            var filter = Builders<BaseUser>.Filter.OfType<DataConsumer>();
            _database.GetCollection<BaseUser>("StaffUser").DeleteMany(filter);
        }

        [HttpGet("deletealldatacoordinators")]
        public void DeleteAllDataCoordinators()
        {
            var filter = Builders<BaseUser>.Filter.OfType<DataCoordinator>();
            _database.GetCollection<BaseUser>("StaffUser").DeleteMany(filter);
        }

        [HttpGet("deletealldataowners")]
        public void DeleteAllDataOwners()
        {
            var filter = Builders<BaseUser>.Filter.OfType<DataOwner>();
            _database.GetCollection<BaseUser>("StaffUser").DeleteMany(filter);
        }

        [HttpGet("deletealldataverifiers")]
        public void DeleteAllDataVerifiers()
        {
            var filter = Builders<BaseUser>.Filter.OfType<DataVerifier>();
            _database.GetCollection<BaseUser>("StaffUser").DeleteMany(filter);
        }

        [HttpGet("deleteallsystemconfigurators")]
        public void DeleteAllSystemConfigurators()
        {
            var filter = Builders<BaseUser>.Filter.OfType<SystemConfigurator>();
            _database.GetCollection<BaseUser>("StaffUser").DeleteMany(filter);
        }

        #endregion

        [HttpGet("deletedatacollectorcollection")]
        public void DeleteDataCollectors()
        {
            DeleteCollection<DataCollector>("DataCollectors");
        }

        [HttpGet("deletegreetinghistorycollection")]
        public void DeleteGreetingHistory()
        {
            DeleteCollection<GreetingHistory>("GreetingHistories");
        }

        #endregion
    }
}
