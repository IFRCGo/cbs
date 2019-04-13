using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.TestData;
using Read;
using Read.CaseReports;
using Read.HealthRisks;
using Read.DataCollectors;
using Read.Alerts;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDataGeneratorController : ControllerBase
    {
        private readonly ICaseReportsEventHandler _caseReportsEventHandler;
        private readonly IHealthRisksEventHandler _healthRisksEventHandler;
        private readonly IDataCollectorsEventHandler _dataCollectorsEventHandler;
        private readonly IAlertEventHandler _alertEventHandler;
        private readonly MongoDBHandler _mongoDbHandler;

        public TestDataGeneratorController(ICaseReportsEventHandler caseReportsEventHandler,
            IHealthRisksEventHandler healthRisksEventHandler,
            IDataCollectorsEventHandler dataCollectorsEventHandler,
            IAlertEventHandler alertEventHandler,
            MongoDBHandler mongoDbHandler)

        {
            _caseReportsEventHandler = caseReportsEventHandler;
            _healthRisksEventHandler = healthRisksEventHandler;
            _dataCollectorsEventHandler = dataCollectorsEventHandler;
            _alertEventHandler = alertEventHandler;
            _mongoDbHandler = mongoDbHandler;
        }

        [HttpGet("{daysToGenerate}", Name = "All")]
        public ActionResult GenerateTestData(int daysToGenerate)
        {
            var healthRisks = new Dictionary<Guid, string>
            {
                { new Guid("c8fc3010-05d7-49b6-9ad0-97d83a3bfe59"), "Cholera" },
                { new Guid("1bbe74fa-a1f4-4204-9cc4-9e8190a1184f"), "Acute Watery Diarrhea" },
                { new Guid("8eabbdad-7f01-43ff-9ed0-bba1b00df051"), "Measels" }
            };

            var dataCollectorIds = GetDataCollectorGuids();
            var gpsCoordinates = GetGpsCoordinates(healthRisks);

            GenerateHealthRisks(healthRisks);
            GenerateDataCollectors(dataCollectorIds);
            GenerateCaseReports(daysToGenerate, dataCollectorIds, gpsCoordinates);
            GenerateAlerts(healthRisks);

            return Ok();
        }

        [HttpGet("CaseReports")]
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


        [HttpGet("HealthRisks")]
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
            foreach (var keyValuePair in healthRisks)
            {
                var healthRisk = new HealthRisk(keyValuePair.Key, keyValuePair.Value);
                _healthRisksEventHandler.Handle(healthRisk);
            }
        }

        private void GenerateAlerts(Dictionary<Guid, string> healthRisks)
        {
            foreach(var keyValuePair in healthRisks)
            {
                var alert = new Alert();
                _alertEventHandler.Handle(alert);
            }
        }

        private void GenerateCaseReports(int daysToGenerate, 
            List<Guid> dataCollectorGuids, List<Tuple<double, double, Guid>> gpsLocations)
        {
            var maxNumberOfReportsDaily = 7;
            var maxNumberOfMalesUnderFive = 3;
            var maxNumberOfMalesFiveOrAbove = 5;
            var maxNumberOfFemalesUnderFive = 6;
            var maxNumberOfFemalesFiveOrAbove = 10;

            Random rnd = new Random();
            for (int dayOffset = daysToGenerate; dayOffset >= 0; dayOffset--)
            {
                var numberOfDailyReports = rnd.Next(maxNumberOfReportsDaily);
                for (int j = 0; j < numberOfDailyReports; j++)
                {
                    var gpsRandom = new Random().Next(0, gpsLocations.Count - 1);
                    var caseReport = new CaseReport(
                        Guid.NewGuid(),
                        dataCollectorGuids.ElementAt(rnd.Next(0, dataCollectorGuids.Count - 3)),
                        gpsLocations.ElementAt(gpsRandom).Item3,
                        "phoneNumber",
                        "test message",
                        rnd.Next(maxNumberOfMalesUnderFive),
                        rnd.Next(maxNumberOfMalesFiveOrAbove),
                        rnd.Next(maxNumberOfFemalesUnderFive),
                        rnd.Next(maxNumberOfFemalesFiveOrAbove),
                        gpsLocations.ElementAt(gpsRandom).Item2,
                        gpsLocations.ElementAt(gpsRandom).Item1,
                        DateTimeOffset.UtcNow.AddDays(-dayOffset));

                    _caseReportsEventHandler.Handle(caseReport);
                }
            }
        }

        private void GenerateDataCollectors(List<Guid> dataCollectorIds)
        {
            foreach (var dataCollectorId in dataCollectorIds)
            {
                _dataCollectorsEventHandler.Handle(new DataCollector(dataCollectorId));
            }
        }

        private List<Guid> GetDataCollectorGuids()
        {
            return new List<Guid>
            {
                { new Guid("89f43918-38a2-4f69-a470-4933ea2df054") },
                { new Guid("2af3bc62-ea80-46a1-93e9-8026054c020e") },
                { new Guid("34f201d7-1132-4fec-9850-af3f4767e4ac")},
                { new Guid("193154f0-747e-4047-b1d3-9ce41588fa13")},
                { new Guid("54053de0-2fcb-4310-bf8d-963fd332ded9")},
                { new Guid("0809f540-7775-47e8-a30e-270d306c80c1")},
                { new Guid("5dbd66fb-7bc6-4fe7-9eca-cf82fa9f6229")},
                { new Guid("068681f5-27a6-4193-82d6-d3c05fdd5faf")},
                { new Guid("ce0cfaff-d37b-4b8f-8774-3f5b98c7fe88")},
                { new Guid("bec75f67-bc9a-471b-a4e5-f540577c98df")},
                { new Guid("4406c02a-2c3e-4bc4-9705-c39222425314")},
                { new Guid("84a0a4c9-cee6-43a2-a65a-95cf73013c9a")}
            };
        }

        private List<Tuple<double, double, Guid>> GetGpsCoordinates(Dictionary<Guid, string> healthRisks)
        {
            return new List<Tuple<double, double, Guid>>
            {
                {new Tuple<double, double, Guid>(48.86672, 2.3333, healthRisks.ElementAt(0).Key) },
                {new Tuple<double, double, Guid>(48.0004, 0.1, healthRisks.ElementAt(1).Key) },
                {new Tuple<double, double, Guid>(48.3404, 4.0834, healthRisks.ElementAt(2).Key) },
                {new Tuple<double, double, Guid>(48.58, 7.75, healthRisks.ElementAt(0).Key) }
            };
        }
    }
}
