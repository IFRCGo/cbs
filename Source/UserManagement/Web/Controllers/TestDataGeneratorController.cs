
using System;
using System.Collections.Generic;
using System.IO;
using Concepts;
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
        private static readonly Random rng = new Random();
        private readonly IMongoDatabase _database;
        private readonly Domain.DataCollector.IDataCollectorCommandHandler _dataCollectorCommandHandler;
        private readonly IRegisteringCommandHandlers _staffUserCommandHandler;

        private readonly IStaffUsersForReading _staffUseresForReading;

        public TestDataGeneratorController(
            IMongoDatabase database,
            Domain.DataCollector.IDataCollectorCommandHandler dataCollectorCommandHandler,
            IRegisteringCommandHandlers staffUserCommandHandler,
            IStaffUsersForReading staffUsersForReading
        )
        {
            _database = database;
            _staffUserCommandHandler = staffUserCommandHandler;
            _dataCollectorCommandHandler = dataCollectorCommandHandler;
            _staffUseresForReading = staffUsersForReading;
        }

        [HttpGet("testpolycol")]
        public async void TestPolymorphicCollection()
        {
            DeleteCollection<BaseUser>("StaffUsersForReading");

            var adminId = Guid.NewGuid();
            var dataConsumerId = Guid.NewGuid();
            var systemConfiguratorId = Guid.NewGuid();

            _staffUseresForReading.Save(new Admin
            (
                adminId,
                "Admin1",
                "Admin1_Disp",
                "Admin1@mail.com",
                DateTimeOffset.UtcNow
            ));
            _staffUseresForReading.Save(new DataConsumer
            (

                dataConsumerId,
                "DataConsumer1",
                "DataConsumer1_Disp",
                "DataConsumer1@mail.com",
                DateTimeOffset.UtcNow,
                new Location(rng.NextDouble(), rng.NextDouble()),
                Guid.NewGuid(),
                Language.English,
                2000,
                Sex.Female
            ));
            _staffUseresForReading.Save(new SystemConfigurator
            (
                systemConfiguratorId,
                "SystemConfigurator1",
                "SystemConfigurator1_Disp",
                "SystemConfigurator1@mail.com",
                DateTimeOffset.UtcNow,
                2000,
                Sex.Male,
                Guid.NewGuid(),
                Language.French
            ));

            Admin b = _staffUseresForReading.GetById<Admin>(adminId);
            DataConsumer dc = _staffUseresForReading.GetById<DataConsumer>(dataConsumerId);
            SystemConfigurator sc = _staffUseresForReading.GetById<SystemConfigurator>(systemConfiguratorId);
            BaseUser sc2 = _staffUseresForReading.GetById<BaseUser>(systemConfiguratorId);

            IEnumerable<BaseUser> allUsers = _staffUseresForReading.GetAll<BaseUser>();
            IEnumerable<Admin> allAdmins = _staffUseresForReading.GetAll<Admin>();
            IEnumerable<BaseUser> allDataConsumers = _staffUseresForReading.GetAll<DataConsumer>();

            IEnumerable<BaseUser> allUsers2 = await _staffUseresForReading.GetAllAsync<BaseUser>();
            IEnumerable<Admin> allAdmins2 = await _staffUseresForReading.GetAllAsync<Admin>();
            IEnumerable<BaseUser> allDataConsumers2 = await _staffUseresForReading.GetAllAsync<DataConsumer>();

            _staffUseresForReading.Save(new SystemConfigurator(
                adminId,
                "SystemConfigurator2",
                "SystemConfigurator2_Disp",
                "SystemConfigurator2@mail.com",
                DateTimeOffset.UtcNow,
                2001,
                Sex.Male,
                Guid.NewGuid(),
                Language.French
                ));

            try
            {
                Admin a1 = _staffUseresForReading.GetById<Admin>(adminId);
            }
            catch (UserNotOfExpectedType)
            {
            }
            SystemConfigurator sc3 = _staffUseresForReading.GetById<SystemConfigurator>(adminId);


            Console.WriteLine();
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
                TestDataGenerator.GenerateCorrectAddDataCollectorCommands();
                commands = JsonConvert.DeserializeObject<RegisterDataCollector[]>(
                    System.IO.File.ReadAllText("./TestData/DataCollectors.json"));
            }

            foreach (var cmd in commands)
            {
                //TODO: Question: Set Id here, in CommandHandler or make the request contain the Id?
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
                TestDataGenerator.GenerateCorrectAddStaffUserCommands();
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
                TestDataGenerator.GenerateCorrectAddStaffUserCommands();
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
                TestDataGenerator.GenerateCorrectAddStaffUserCommands();
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
                TestDataGenerator.GenerateCorrectAddStaffUserCommands();
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
                TestDataGenerator.GenerateCorrectAddStaffUserCommands();
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
                TestDataGenerator.GenerateCorrectAddStaffUserCommands();
                commands = JsonConvert.DeserializeObject<RegisterNewSystemConfigurator[]>(
                    System.IO.File.ReadAllText("./TestData/SystemConfigurators.json"));
            }

            foreach (var cmd in commands)
            {
                _staffUserCommandHandler.Handle(cmd);
            }
        }
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
            //DeleteCollection<Read.StaffUsers.StaffUser>("StaffUser");
            //DeleteCollection<Read.StaffUsers.SystemCoordinator.SystemCoordinator>("SystemCoordinator");
            //DeleteCollection<Read.StaffUsers.DataVerifier.DataVerifier>("DataVerifier");
            //DeleteCollection<Read.StaffUsers.DataOwner.DataOwner>("DataOwner");
            //DeleteCollection<Read.StaffUsers.DataCoordinator.DataCoordinator>("DataCoordinator");
            //DeleteCollection<Read.StaffUsers.DataConsumer.DataConsumer>("DataConsumer");
            //DeleteCollection<Read.StaffUsers.Admin.Admin>("Admin");

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

    }
}