using System;
using System.IO;
using Domain.DataCollector.Registering;
using Domain.StaffUser.Registering;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using Read.DataCollectors;
using Read.GreetingGenerators;
using Web.TestData;
using Dolittle.Commands.Coordination;
using Read.StaffUsers.Models;
using Read.StaffUsers.Admin;
using Read.StaffUsers.DataConsumer;
using Read.StaffUsers.DataCoordinator;
using Read.StaffUsers.DataOwner;
using Read.StaffUsers.DataVerifier;
using Read.StaffUsers.SystemConfigurator;

namespace Web.Controllers
{
    [Route("api/testdatagenerator")]
    public class TestDataGeneratorController : Controller
    {
        private readonly ICommandCoordinator _commandCoordinator;

        private readonly IAdminRepository _adminRepository;
        private readonly IDataCoordinatorRepository _dataCoordinatorRepository;
        private readonly IDataOwnerRepository _dataOwnerRepository;
        private readonly IDataVerifierRepository _dataVerifierRepository;
        private readonly ISystemConfiguratorRepository _systemConfiguratorRepository;
        private readonly IDataConsumerRepository _dataConsumerRepository;

        private readonly IDataCollectors _dataCollectors;
        private readonly IGreetingHistories _greetingHistories;

        public TestDataGeneratorController(
            ICommandCoordinator commandCoordinator,
            IAdminRepository adminRepository,
            IDataConsumerRepository dataConsumerRepository,
            IDataCoordinatorRepository dataCoordinatorRepository,
            IDataOwnerRepository dataOwnerRepository,
            IDataVerifierRepository dataVerifierRepository,
            ISystemConfiguratorRepository systemConfiguratorRepository,
            
            IDataCollectors dataCollectors,
            IGreetingHistories greetingHistories)
        {
            _commandCoordinator = commandCoordinator;
            _adminRepository = adminRepository;
            _dataCoordinatorRepository = dataCoordinatorRepository;
            _dataOwnerRepository = dataOwnerRepository;
            _dataVerifierRepository = dataVerifierRepository;
            _systemConfiguratorRepository = systemConfiguratorRepository;
            _dataConsumerRepository = dataConsumerRepository;

            _dataCollectors = dataCollectors;
            _greetingHistories = greetingHistories;
        }
       

        [HttpPut("newTest")]
        public void TestNew()
        {
            var adminId = Guid.NewGuid();
            
            _adminRepository.Insert(new Admin(
                adminId,
                "name",
                "dispname",
                "email@live.no",
                DateTimeOffset.UtcNow
                ));

            _adminRepository.UpdateOne(Builders<Admin>.Filter.Where(a => a.StaffUserId == adminId),
                Builders<Admin>.Update.Set(a => a.FullName, "newName"));
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
                //TODO: Einari, this is  really weird
                var res = _commandCoordinator.Handle(cmd);
                var validator = new RegisterNewAdminUserInputValidator();

                var resValidation = validator.Validate(cmd);
                Console.Write(resValidation);
                Console.Write(res);
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

        #region StaffUser

        [HttpGet("deleteallstaffusercollections")]
        public void DeleteAllStaffUserCollections()
        {
        }
        
        [HttpGet("deletealladmins")]
        public void DeleteAllAdmins()
        {
            
        }

        [HttpGet("deletealldataconsumers")]
        public void DeleteAllDataConsumers()
        {
        }

        [HttpGet("deletealldatacoordinators")]
        public void DeleteAllDataCoordinators()
        {
        }

        [HttpGet("deletealldataowners")]
        public void DeleteAllDataOwners()
        {
        }

        [HttpGet("deletealldataverifiers")]
        public void DeleteAllDataVerifiers()
        {
        }

        [HttpGet("deleteallsystemconfigurators")]
        public void DeleteAllSystemConfigurators()
        {
        }

        #endregion

        [HttpGet("deletedatacollectorcollection")]
        public void DeleteDataCollectors()
        {
            
        }

        [HttpGet("deletegreetinghistorycollection")]
        public void DeleteGreetingHistory()
        {

        }

        #endregion
    }
}
