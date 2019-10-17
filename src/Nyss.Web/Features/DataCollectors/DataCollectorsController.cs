
using Microsoft.AspNetCore.Mvc;
using Nyss.Web.Utils;

namespace Nyss.Web.Features.DataCollectors
{
    public class DataCollectorsController : BaseController
    {
        private readonly IDataCollectorsService _dataCollectorService;

        public DataCollectorsController(IDataCollectorsService dataCollectorService)
        {
            _dataCollectorService = dataCollectorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dataCollectorService.All());
        }
    }
}
