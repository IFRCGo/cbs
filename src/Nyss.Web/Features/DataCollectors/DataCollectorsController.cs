
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

        public IActionResult GetAll()
        {
            return Ok(_dataCollectorService.All());
        }
    }
}
