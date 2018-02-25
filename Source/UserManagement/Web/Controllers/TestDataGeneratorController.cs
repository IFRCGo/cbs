using System;
using System.IO;
using System.Threading.Tasks;
using Domain.DataCollectors.CommandHandlers;
using Domain.DataCollectors.Commands;
using Domain.StaffUser.CommandHandlers;
using Domain.StaffUser.Commands;
using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using Read.DataCollectors;
using Read.GreetingGenerators;
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
        private readonly IDataCollectorCommandHandler _dataCollectorCommandHandler;
        private readonly IStaffUserCommandHandler _staffUserCommandHandler;

        public TestDataGeneratorController(
            IMongoDatabase database,
            IDataCollectorCommandHandler dataCollectorCommandHandler,
            IStaffUserCommandHandler staffUserCommandHandler
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
                //TODO: Question: Set Id here, in CommandHandler or make the request contain the Id?
                cmd.DataCollectorId = Guid.NewGuid();
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
                //TODO: Question: Set Id here, in CommandHandler or make the request contain the Id?
                cmd.StaffUserId = Guid.NewGuid();
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
            DeleteCollection<StaffUser>("StaffUser");
            DeleteCollection<SystemCoordinator>("SystemCoordinator");
            DeleteCollection<DataVerifier>("DataVerifier");
            DeleteCollection<DataOwner>("DataOwner");
            DeleteCollection<DataCoordinator>("DataCoordinator");
            DeleteCollection<DataConsumer>("DataConsumer");
            DeleteCollection<Admin>("Admin");

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