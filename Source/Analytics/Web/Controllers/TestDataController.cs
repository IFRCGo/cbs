using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.TestData;
using Read;
using CaseReport = Read.CaseReport;

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
            var caseReports = JsonConvert.DeserializeObject<TestData.CaseReport[]>(System.IO.File.ReadAllText("TestData/CaseReports.json"));
            var mongoDbHandler = new MongoDBHandler();

            foreach (var caseReport in caseReports)
            {
                var dbCaseEntry = new CaseReport(caseReport.DataCollectorId,
                    caseReport.NumberOfMalesAged5AndOlder,
                    caseReport.NumberOfFemalesUnder5,
                    caseReport.NumberOfFemalesAged5AndOlder,
                    caseReport.NumberOfMalesUnder5,
                    DateTimeOffset.UtcNow,
                    caseReport.HealthRiskId,
                    caseReport.Origin,
                    caseReport.Longitude,
                    caseReport.Latitude);

                mongoDbHandler.insertGenericRecordToDB(dbCaseEntry);
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

                mongoDbHandler.insertGenericRecordToDB(dbDataOwnerEntry);
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
    }
}
