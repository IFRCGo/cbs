using System;
using System.IO;
using System.Threading.Tasks;
using Domain;
using Domain.DataCollectors.CommandHandlers;
using Domain.DataCollectors.Commands;
using Domain.StaffUser.CommandHandlers;
using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using Read.DataCollectors;
using Read.StaffUsers;
using Read.StaffUsers.Admin;
using Read.StaffUsers.DataConsumer;
using Read.StaffUsers.DataCoordinator;
using Read.StaffUsers.DataOwner;
using Read.StaffUsers.DataVerifier;
using Read.StaffUsers.SystemCoordinator;
using Web.TestData;

namespace Web.Controllers
{
    [Route("api/testdatagenerator")]
    public class TestDataGeneratorController : BaseController
    {
        private readonly IMongoDatabase _database;
        private readonly DataCollectorCommandHandler _dataCollectorCommandHandler;
        private readonly StaffUserCommandHandler _staffUserCommandHandler;

        public TestDataGeneratorController(
            IMongoDatabase database,
            DataCollectorCommandHandler dataCollectorCommandHandler,
            StaffUserCommandHandler staffUserCommandHandler
        )
        {
            _database = database;
            _staffUserCommandHandler = staffUserCommandHandler;
            _dataCollectorCommandHandler = dataCollectorCommandHandler;
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
            AddDataCollector[] commands;
            try
            {
                commands = JsonConvert.DeserializeObject<AddDataCollector[]>(
                        System.IO.File.ReadAllText("./TestData/DataCollectors.json"));
            }
            catch (FileNotFoundException e)
            {
                TestDataGenerator.GenerateCorrectAddDataCollectorCommands();
                commands = JsonConvert.DeserializeObject<AddDataCollector[]>(
                    System.IO.File.ReadAllText("./TestData/DataCollectors.json"));
            }

            foreach (var cmd in commands)
            {
                _dataCollectorCommandHandler.Handle(cmd);
            }
            
        }

        [HttpGet("allstaffusercommands")]
        public void CreateAllStaffUserCommands()
        {
            DeleteAllStaffUserCollections();
            AddStaffUser[] commands;
            try
            {
                commands = JsonConvert.DeserializeObject<AddStaffUser[]>(
                    System.IO.File.ReadAllText("./TestData/StaffUsers.json"));
            }
            catch (FileNotFoundException e)
            {
                TestDataGenerator.GenerateCorrectAddDataCollectorCommands();
                commands = JsonConvert.DeserializeObject<AddStaffUser[]>(
                    System.IO.File.ReadAllText("./TestData/StaffUsers.json"));
            }

            foreach (var cmd in commands)
            {
                _staffUserCommandHandler.Handle(cmd);
            }

        }


        private void DeleteCollection<T>(string collectionName)
        {
            _database.GetCollection<T>(collectionName).DeleteMany(_ => true);
        }

        private void DeleteAllStaffUserCollections()
        {
            DeleteCollection<StaffUser>("StaffUser");
            DeleteCollection<SystemCoordinator>("SystemCoordinator");
            DeleteCollection<DataVerifier>("DataVerifier");
            DeleteCollection<DataOwner>("DataOwner");
            DeleteCollection<DataCoordinator>("DataCoordinator");
            DeleteCollection<DataConsumer>("DataConsumer");
            DeleteCollection<Admin>("Admin");
            
        }

    }
}