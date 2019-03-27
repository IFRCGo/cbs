using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.TestData;
using Read;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDataController : ControllerBase
    {
        // GET api/TestData
        [HttpGet]
        public ActionResult<IEnumerable<string>> GenerateTestData()
        {
            var caseReports = JsonConvert.DeserializeObject<CaseReport[]>(System.IO.File.ReadAllText("TestData/CaseReports.json"));
            var mongoDbHandler = new MongoDBHandler();

            foreach (var caseReport in caseReports)
            {
                var dbCaseEntry = new DbCaseEntry(caseReport.DataCollectorId,
                    caseReport.NumberOfMalesAged5AndOlder,
                    caseReport.NumberOfFemalesUnder5,
                    caseReport.NumberOfFemalesAged5AndOlder,
                    caseReport.NumberOfMalesUnder5,
                    DateTimeOffset.UtcNow,
                    caseReport.HealthRiskId,
                    caseReport.Origin,
                    caseReport.Longitude,
                    caseReport.Latitude);

                mongoDbHandler.InsertRecordToDB(dbCaseEntry);
            }
            
            return caseReports.Select(x => x.Message).ToArray();
        }

        // GET api/TestData/dataowner
        [HttpGet("dataowner")]
        public ActionResult<IEnumerable<string>> GenerateTestDataOwner()
        {
            var dataOwners = JsonConvert.DeserializeObject<DataOwners[]>(System.IO.File.ReadAllText("TestData/DataOwners.json"));
            var mongoDbHandler = new MongoDBHandler();

            foreach (var dataOwner in dataOwners)
            {
                var dbDataOwnerEntry = new DbDataOwnerEntry(dataOwner.DataOwnerId, dataOwner.Name, dataOwner.Longitude, dataOwner.Latitude, dataOwner.DataCollectors);

                mongoDbHandler.InsertDataOwnerRecordToDB(dbDataOwnerEntry);
            }

            return dataOwners.Select(x => x.Name).ToArray();
        }

        // GET api/TestData/delete
        [HttpGet("delete")]
        public string DeleteTestData()
        {
            var mongoDbHandler = new MongoDBHandler();
            mongoDbHandler.DeleteAllRecordsFromDB();
            return "test";
        }

        // GET api/TestData/{dataowner}
        [HttpGet("guid")]
        public string FetchTestDataOwner()
        {
            var mongoDbHandler = new MongoDBHandler();
            var testDataService = new TestDataService(mongoDbHandler);
            var guid = new Guid("a987c35c-1c7a-4bd3-a449-a071ffeb71e7");
            var dataOwner = testDataService.GetDataOwner(guid);

            string result = "DataOwner: " + dataOwner.DataOwnerId;
            foreach (var dataCollector in dataOwner.DataCollectorReports)
            {
                result = string.Concat(result, " DataCollector: ", dataCollector.DataCollectorId);
                foreach (var report in dataCollector.HealthRiskAggregatedReports)
                {
                    result = string.Concat(result, "HealthReport: ", report.HealthRiskId, " ", report.NumberOfFemalesAged5AndOlder, "\n");
                }
            }

            return result;
        }
    }
}
