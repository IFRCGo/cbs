using Infrastructure.Events;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Read;
using MongoDB.Driver;
using Newtonsoft.Json;
using Events.External;
using Read.HealthRiskFeatures;

namespace Web
{
    [Route("api/testdatagenerator")]
    public class TestDataGeneratorController
    {
        private IEventEmitter _eventEmitter;
        private IMongoDatabase _database;

        public TestDataGeneratorController(IEventEmitter eventEmitter, IMongoDatabase database)
        {
            _eventEmitter = eventEmitter;
            _database = database;
        }

        [HttpGet("all")]
        public void CreateAll()
        {
            CreateDataCollectors();
            CreateHealthRisks();
        }

        [HttpGet("datacollectors")]
        public void CreateDataCollectors()
        {
            var _collection = _database.GetCollection<DataCollector>("DataCollector");
            _collection.DeleteMany(v => true);

            var dataCollectors = JsonConvert.DeserializeObject<DataCollectorAdded[]>(File.ReadAllText("./TestData/DataCollectors.json"));
            foreach (var dataCollector in dataCollectors)
                _eventEmitter.Emit("DataCollectorAdded", dataCollector);
        }

        [HttpGet("healthrisks")]
        public void CreateHealthRisks()
        {
            var _collection = _database.GetCollection<HealthRisk>("HealthRisks");
            _collection.DeleteMany(v => true);

            var healthRisks = JsonConvert.DeserializeObject<HealthRiskCreated[]>(File.ReadAllText("./TestData/HealthRisks.json"));
            foreach (var healthRisk in healthRisks)
                _eventEmitter.Emit("HealthRiskCreated", healthRisk);
        }
    }
}
