using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Web.TestData;

namespace Web.Controllers
{
    [Route("api/testdatagenerator")]
    public class TestDataGeneratorController : BaseController
    {
        public TestDataGeneratorController() { }

        [HttpGet("generatetestdataset")]
        public void GenerateTestDataSet()
        {
            TestDataGenerator.GenerateAllTestData();
        }
        [HttpGet("handletestdatacommands")]
        public void HandleTestDataCommands()
        {
            //TODO: Read commands from JSON and give them to the CommandHandlers

        }
    }
}