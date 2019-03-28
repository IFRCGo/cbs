using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.TestData;
using Read;
using Read.CaseReports;
using Read.HealthRisks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDataGeneratorController : ControllerBase
    {
        private readonly ICaseReportsEventHandler _caseReportsEventHandler;
        private readonly IHealthRisksEventHandler _healthRisksEventHandler;
        private readonly MongoDBHandler _mongoDbHandler;

        public TestDataGeneratorController(ICaseReportsEventHandler caseReportsEventHandler,
            IHealthRisksEventHandler healthRisksEventHandler,
            MongoDBHandler mongoDbHandler)
  
        {
            _caseReportsEventHandler = caseReportsEventHandler;
            _healthRisksEventHandler = healthRisksEventHandler;
            _mongoDbHandler = mongoDbHandler;
        }

        [HttpGet("{daysToGenerate}", Name= "All")]
        public ActionResult GenerateTestData(int daysToGenerate)
        {
            var healthRisks = new Dictionary<Guid, string>();
            healthRisks.Add(new Guid("c8fc3010-05d7-49b6-9ad0-97d83a3bfe59"), "Cholera");
            healthRisks.Add(new Guid("1bbe74fa-a1f4-4204-9cc4-9e8190a1184f"), "Acute Watery Diarrhea");
            healthRisks.Add(new Guid("8eabbdad-7f01-43ff-9ed0-bba1b00df051"), "Measels");

            GenerateHealthRisks(healthRisks);
            GenerateCaseReports(daysToGenerate, healthRisks);

            return Ok();
        }

        [HttpGet(Name = "CaseReports")]
        public ActionResult<IEnumerable<string>> CaseReports()
        {
            var caseReports = JsonConvert.DeserializeObject<CaseReport[]>(System.IO.File.ReadAllText("./TestData/CaseReports.json"));
            foreach (var caseReport in caseReports)
            {
                var report = new CaseReport(
                    Guid.NewGuid(),
                    caseReport.DataCollectorId,
                    caseReport.HealthRisk,
                    caseReport.Origin,
                    caseReport.Message,
                    caseReport.NumberOfMalesUnder5,
                    caseReport.NumberOfMalesAged5AndOlder,
                    caseReport.NumberOfFemalesUnder5,
                    caseReport.NumberOfFemalesAged5AndOlder,
                    caseReport.Longitude,
                    caseReport.Latitude,
                    DateTimeOffset.UtcNow);

                _caseReportsEventHandler.Handle(report);
            }

            return caseReports.Select(x => x.Message).ToArray();
        }


        [HttpGet(Name = "HealthRisks")]
        public ActionResult<IEnumerable<string>> HealthRisks()
        {
            var caseReports = JsonConvert.DeserializeObject<CaseReport[]>(System.IO.File.ReadAllText("./TestData/CaseReports.json"));
            foreach (var caseReport in caseReports)
            {
                var report = new CaseReport(
                    Guid.NewGuid(),
                    caseReport.DataCollectorId,
                    caseReport.HealthRisk,
                    caseReport.Origin,
                    caseReport.Message,
                    caseReport.NumberOfMalesUnder5,
                    caseReport.NumberOfMalesAged5AndOlder,
                    caseReport.NumberOfFemalesUnder5,
                    caseReport.NumberOfFemalesAged5AndOlder,
                    caseReport.Longitude,
                    caseReport.Latitude,
                    DateTimeOffset.UtcNow);

                _caseReportsEventHandler.Handle(report);
            }

            return caseReports.Select(x => x.Message).ToArray();
        }

        // GET api/TestData/dataowner
        [HttpGet("DataCollectors")]
        public ActionResult<IEnumerable<string>> GenerateTestDataOwner()
        {
            var dataOwners = JsonConvert.DeserializeObject<DataOwners[]>(System.IO.File.ReadAllText("TestData/DataOwners.json"));

            foreach (var dataOwner in dataOwners)
            {
                var dbDataOwnerEntry = new DataOwner(dataOwner.DataOwnerId, dataOwner.Name, dataOwner.Longitude, dataOwner.Latitude, dataOwner.DataCollectors);

                _mongoDbHandler.Insert(dbDataOwnerEntry);
            }

            return dataOwners.Select(x => x.Name).ToArray();
        }

        // GET api/TestData/{dataowner}
        [HttpGet("guid")]
        public string FetchTestDataOwner()
        {
            var testDataService = new TestDataService(_mongoDbHandler);
            var guid = new Guid("a987c35c-1c7a-4bd3-a449-a071ffeb71e7");
            return testDataService.GetDataOwner(guid);
        }

        private void GenerateHealthRisks(Dictionary<Guid, string> healthRisks)
        {
            foreach(var keyValuePair in healthRisks)
            {
                var healthRisk = new HealthRisk(keyValuePair.Key, keyValuePair.Value);
                _healthRisksEventHandler.Handle(healthRisk);
            }
        }

            private void GenerateCaseReports(int daysToGenerate, Dictionary<Guid, string> healthRisks)
        {
            var maxNumberOfReportsDaily = 10;
            var maxNumberOfMalesUnderFive = 40;
            var maxNumberOfMalesFiveOrAbove = 100;
            var maxNumberOfFemalesUnderFive = 40;
            var maxNumberOfFemalesFiveOrAbove = 100;

            Random rnd = new Random();
            for (int dayOffset = daysToGenerate; dayOffset >= 0; dayOffset--)
            {
                var numberOfDailyReports = rnd.Next(maxNumberOfReportsDaily);
                for (int j = 0; j < numberOfDailyReports; j++)
                {
                    var caseReport = new CaseReport(
                        Guid.NewGuid(),
                        Guid.NewGuid(),
                        healthRisks.ElementAt(rnd.Next(0, healthRisks.Count)).Key,
                        "phoneNumber",
                        "test message",
                        rnd.Next(maxNumberOfMalesUnderFive),
                        rnd.Next(maxNumberOfMalesFiveOrAbove),
                        rnd.Next(maxNumberOfFemalesUnderFive),
                        rnd.Next(maxNumberOfFemalesFiveOrAbove),
                        rnd.Next(-180, 180),
                        rnd.Next(-90, 90),
                        DateTimeOffset.UtcNow.AddDays(-dayOffset));

                    _caseReportsEventHandler.Handle(caseReport);
                }
            }
        }
    }
}
