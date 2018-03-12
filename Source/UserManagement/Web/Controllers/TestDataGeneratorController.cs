using System;
using System.IO;
using Domain.DataCollector.Registering;
using Domain.StaffUser.Registering;
using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using Read.DataCollectors;
using Read.GreetingGenerators;
using Read.StaffUsers;
using Read.StaffUsers.Models;
using Web.TestData;

namespace Web.Controllers
{
    [Route("api/testdatagenerator")]
    public class TestDataGeneratorController : BaseController
    {
        private readonly IMongoDatabase _database;
        private readonly Domain.DataCollector.IDataCollectorCommandHandler _dataCollectorCommandHandler;
        private readonly IRegisteringCommandHandlers _staffUserCommandHandler;

        private readonly IStaffUsers _staffUsers;

        public TestDataGeneratorController(
            IMongoDatabase database,
            Domain.DataCollector.IDataCollectorCommandHandler dataCollectorCommandHandler,
            IRegisteringCommandHandlers staffUserCommandHandler,
            IStaffUsers staffUsers
        )
        {
            _database = database;
            _staffUserCommandHandler = staffUserCommandHandler;
            _dataCollectorCommandHandler = dataCollectorCommandHandler;
            _staffUsers = staffUsers;
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
            DeleteCollection<DataCollector>("DataCollector");
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
                _dataCollectorCommandHandler.Handle(cmd);
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
            //Delete Admin collection
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
                _staffUserCommandHandler.Handle(cmd);
            }
        }
        [HttpGet("alldataconsumercommands")]
        public void CreateAllDataConsumerCommands()
        {
            //Delete DataConsumer collection
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
                _staffUserCommandHandler.Handle(cmd);
            }
        }
        [HttpGet("alldatacoordinatorcommands")]
        public void CreateAllDataCoordinatorCommands()
        {
            //Delete DataCoordinator collection
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
                _staffUserCommandHandler.Handle(cmd);
            }
        }
        [HttpGet("alldataownercommands")]
        public void CreateAllDataOwnerCommands()
        {
            //Delete DataOwner collection
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
                _staffUserCommandHandler.Handle(cmd);
            }
        }
        [HttpGet("alldataverifiercommands")]
        public void CreateAllDataVerifierCommands()
        {
            //Delete DataVerifier collection
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
                _staffUserCommandHandler.Handle(cmd);
            }
        }
        [HttpGet("allsystemconfiguratorcommands")]
        public void CreateAllSystemConfiguratorCommands()
        {
            //Delete SystemConfigurator collection
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
                _staffUserCommandHandler.Handle(cmd);
            }
        }

        #region Delete collections

        [HttpGet("deleteall")]
        public void DeleteAll()
        {
            DeleteAllStaffUserCollections();
            DeleteDataCollector();
            DeleteGreetingHistory();
        }

        [HttpGet("deleteallstaffusercollections")]
        public void DeleteAllStaffUserCollections()
        {
            DeleteCollection<BaseUser>("StaffUsers");
        }

        [HttpGet("deletealladmins")]
        public void DeleteAllAdmins()
        {
            DeleteCollection<Admin>("StaffUsers");
        }

        [HttpGet("deletealldataconsumers")]
        public void DeleteAllDataConsumers()
        {
            DeleteCollection<DataConsumer>("StaffUsers");
        }

        [HttpGet("deletealldatacoordinators")]
        public void DeleteAllDataCoordinators()
        {
            DeleteCollection<DataCoordinator>("StaffUsers");
        }

        [HttpGet("deletealldataowners")]
        public void DeleteAllDataOwners()
        {
            DeleteCollection<DataOwner>("StaffUsers");
        }

        [HttpGet("deletealldataverifiers")]
        public void DeleteAllDataVerifiers()
        {
            DeleteCollection<DataVerifier>("StaffUsers");
        }

        [HttpGet("deleteallsystemconfigurators")]
        public void DeleteAllSystemConfigurators()
        {
            DeleteCollection<SystemConfigurator>("StaffUsers");
        }


        [HttpGet("deletedatacollectorcollection")]
        public void DeleteDataCollector()
        {
            DeleteCollection<DataCollector>("DataCollector");
        }

        [HttpGet("deletegreetinghistorycollection")]
        public void DeleteGreetingHistory()
        {
            DeleteCollection<GreetingHistory>("GreetingHistories");
        }


        private void DeleteCollection<T>(string collectionName)
        {
            _database.GetCollection<T>(collectionName).DeleteMany(_ => true);
        }

        #endregion
    }
}
