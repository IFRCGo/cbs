
using Domain.DataCollector;
using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Read.GreetingGenerators;
using Web.TestData;

namespace Web.Controllers
{
    [Route("api/testdatagenerator")]
    public class TestDataGeneratorController : BaseController
    {
        private readonly IMongoDatabase _database;
        private readonly DataCollectorCommandHandler _dataCollectorCommandHandler;
        private readonly Domain.StaffUser.Registering.RegisteringCommandHandlers _staffUserCommandHandler;

        public TestDataGeneratorController(
            IMongoDatabase database,
            DataCollectorCommandHandler dataCollectorCommandHandler,
            Domain.StaffUser.Registering.RegisteringCommandHandlers staffUserCommandHandler
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
            // CreateDataCollectorCommands();
            // CreateAllStaffUserCommands();
        }
        
        [HttpGet("datacollectorcommands")]
        public void CreateDataCollectorCommands()
        {
            // DeleteCollection<DataCollector>("DataCollector");
            // RegisterDataCollector[] commands;
            // try
            // {
            //     commands = JsonConvert.DeserializeObject<RegisterDataCollector[]>(
            //             System.IO.File.ReadAllText("./TestData/DataCollectors.json"));
            // }
            // catch (FileNotFoundException e)
            // {
            //     TestDataGenerator.GenerateCorrectAddDataCollectorCommands();
            //     commands = JsonConvert.DeserializeObject<RegisterDataCollector[]>(
            //         System.IO.File.ReadAllText("./TestData/DataCollectors.json"));
            // }

            // foreach (var cmd in commands)
            // {
            //     //TODO: Question: Set Id here, in CommandHandler or make the request contain the Id?
            //     cmd.DataCollectorId = Guid.NewGuid();
            //     _dataCollectorCommandHandler.Handle(cmd);
            // }
            
        }

        [HttpGet("allstaffusercommands")]
        public void CreateAllStaffUserCommands()
        {
            // DeleteAllStaffUserCollections();
            // AddStaffUser[] commands;
            // try
            // {
            //     commands = JsonConvert.DeserializeObject<AddStaffUser[]>(
            //         System.IO.File.ReadAllText("./TestData/StaffUsers.json"));
            // }
            // catch (FileNotFoundException e)
            // {
            //     TestDataGenerator.GenerateCorrectAddDataCollectorCommands();
            //     commands = JsonConvert.DeserializeObject<AddStaffUser[]>(
            //         System.IO.File.ReadAllText("./TestData/StaffUsers.json"));
            // }

            // foreach (var cmd in commands)
            // {
            //     //TODO: Question: Set Id here, in CommandHandler or make the request contain the Id?
            //     cmd.StaffUserId = Guid.NewGuid();
            //     _staffUserCommandHandler.Handle(cmd);
            // }

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
            // DeleteCollection<StaffUser>("StaffUser");
            // DeleteCollection<SystemCoordinator>("SystemCoordinator");
            // DeleteCollection<DataVerifier>("DataVerifier");
            // DeleteCollection<DataOwner>("DataOwner");
            // DeleteCollection<DataCoordinator>("DataCoordinator");
            // DeleteCollection<DataConsumer>("DataConsumer");
            // DeleteCollection<Admin>("Admin");

        }

        [HttpGet("deletedatacollectorcollection")]
        public void DeleteDataCollector()
        {
            DeleteCollection<Read.DataCollectors.DataCollector>("DataCollector");
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