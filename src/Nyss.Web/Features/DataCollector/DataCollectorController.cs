using Nyss.Web.Utils;

namespace Nyss.Web.Features.DataCollector
{
    public class DataCollectorController : BaseController
    {
        private readonly IDataCollectorService _dataCollectorService;

        public DataCollectorController(IDataCollectorService dataCollectorService)
        {
            _dataCollectorService = dataCollectorService;
        }

        //TODO: Add action that returns list of datacollectors
    }
}
