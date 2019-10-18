using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nyss.Web.Utils;

namespace Nyss.Web.Features.DataCollectors.Export
{
    [Route("/api/datacollectors/export")]
    public class DataCollectorExportController : BaseController
    {
        private readonly IDataCollectorsService _dataCollectorsService;
        private readonly ICanExportDataCollectors _exporter;

        public DataCollectorExportController(
            IDataCollectorsService dataCollectorsService,
            ICanExportDataCollectors exporter)
        {
            _dataCollectorsService = dataCollectorsService;
            _exporter = exporter;
        }

        [HttpPost("download")]
        public IActionResult Export([FromBody] DataCollectorsDownloadParameters parameters)
        {
            if (_exporter.Format != parameters.Format)
            {
                return NotFound($"Unknown format, use \"{_exporter.Format}\"");
            }

            var dataCollectors = _dataCollectorsService.All();
            var filtered = dataCollectors.Where(parameters.FilterPredicate);
            var ordered = parameters.OrderDescending
                ? filtered.OrderByDescending(parameters.GetOrderByPredicate)
                : filtered.OrderBy(parameters.GetOrderByPredicate);

            var fileName = "DataCollectors-" + DateTimeOffset.UtcNow.ToString("yyyy-MM-dd") + _exporter.FileExtension;

            var stream = new MemoryStream();
            _exporter.WriteDataCollectorsTo(ordered, stream);
            stream.Position = 0;
            return File(stream, _exporter.MIMEType, fileName);
        }

        public class DataCollectorsDownloadParameters
        {
            public string Format { get; set; }
            public string Filter { get; set; }
            public string FilterValue { get; set; }
            public string SortBy { get; set; }
            public string Order { get; set; }

            internal bool OrderDescending => Order?.ToLower().Equals("desc") ?? false;

            internal Func<DataCollectorViewModel, bool> FilterPredicate
            {
                get
                {
                    if (string.IsNullOrEmpty(Filter) || string.IsNullOrEmpty(FilterValue))
                        return _ => true;

                    switch (Filter?.ToLower())
                    {
                        case "region":
                            return _ => _.Region == FilterValue;
                        case "district":
                            return _ => _.District == FilterValue;
                        case "village":
                            return _ => _.Village == FilterValue;
                        case "zone":
                            return _ => _.Zone == FilterValue;
                        case "supervisor":
                            return _ => _.Supervisor == FilterValue;
                        default:
                            return _ => true;
                    }
                }
            }

            internal Func<DataCollectorViewModel, IComparable> GetOrderByPredicate
            {
                get
                {
                    switch (SortBy?.ToLower())
                    {
                        case "region":
                            return _ => _.Region;
                        case "district":
                            return _ => _.District;
                        case "village":
                            return _ => _.Village;
                        case "zone":
                            return _ => _.Zone;
                        case "supervisor":
                            return _ => _.Supervisor;
                        default:
                            return _ => _.DisplayName;
                    }
                }
            }
        }
    }
}
