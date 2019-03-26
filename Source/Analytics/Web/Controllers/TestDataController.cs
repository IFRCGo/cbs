using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.TestData;

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
            
            return caseReports.Select(x => x.Message).ToArray();
        }
    }
}
