using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Web.TestData;

namespace Web.Controllers
{
    [Route("api/testdatagenerator")]
    public class TestDataGeneratorController : BaseController
    {
        public TestDataGeneratorController() { }

        [HttpGet("generatetestdata")]
        public void GenerateTestData()
        {
            TestDataGenerator.GenerateAllTestData();
        }
    }
}