using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.TestData;
using Read;
using Read.CaseReports;

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
                var dbCaseEntry = new CaseReport(
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

                mongoDbHandler.InsertRecordToDb(dbCaseEntry);
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
                var dbDataOwnerEntry = new DataOwner(dataOwner.DataOwnerId, dataOwner.Name, dataOwner.Longitude, dataOwner.Latitude, dataOwner.DataCollectors);

                mongoDbHandler.InsertRecordToDb(dbDataOwnerEntry);
            }

            return dataOwners.Select(x => x.Name).ToArray();
        }

        // GET api/TestData/delete
        [HttpGet("delete")]
        public string DeleteTestData()
        {
            var mongoDbHandler = new MongoDBHandler();
            // mongoDbHandler.DeleteAllRecordsFromDB();
            return "test";
        }

        // GET api/TestData/{dataowner}
        [HttpGet("guid")]
        public string FetchTestDataOwner()
        {
            var mongoDbHandler = new MongoDBHandler();
            var testDataService = new TestDataService(mongoDbHandler);
            var guid = new Guid("a987c35c-1c7a-4bd3-a449-a071ffeb71e7");
            return testDataService.GetDataOwner(guid);
        }
    }
}
