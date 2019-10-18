using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Nyss.Web.Features.Report.Export
{
    [Route("/api/report/export")]
    public class ReportExportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly ICanExportCaseReports _exporter;

        public ReportExportController(
            IReportService reportService,
            ICanExportCaseReports exporter
        )
        {
            _reportService = reportService;
            _exporter = exporter;
        }

        //[HttpGet("json")]
        //public IActionResult Get()
        //{
        //    _executionContextConfigurator.ConfigureFor(_tenantResolver.Resolve(HttpContext.Request), Dolittle.Execution.CorrelationId.New(), ClaimsPrincipal.Current.ToClaims());

        //    return Ok(_allCaseReports().Query.ToList());
        //}

        [HttpPost("download")]
        public IActionResult Export([FromBody] DownloadParameters parameters)
        {
            if (_exporter.Format != parameters.Format)
            {
                return NotFound("Unknown format, use \"excel\"");
            }

            var reports = _reportService.All();
            var filtered = reports.Where(parameters.FilterPredicate);
            var ordered = parameters.OrderDescending
                ? filtered.OrderByDescending(parameters.GetOrderByPredicate)
                : filtered.OrderBy(parameters.GetOrderByPredicate);

            var fileName = "CaseReports-" + DateTimeOffset.UtcNow.ToString("yyyy-MM-dd") + _exporter.FileExtension;

            var stream = new MemoryStream();
            _exporter.WriteReportsTo(ordered, stream);
            stream.Position = 0;
            return File(stream, _exporter.MIMEType, fileName);
        }

        public class DownloadParameters
        {
            public string Format { get; set; }
            public string Filter { get; set; }
            public string SortBy { get; set; }
            public string Order { get; set; }

            internal bool OrderDescending => !Order?.ToLower().Equals("asc") ?? false;

            internal Func<ReportViewModel, bool> FilterPredicate
            {
                get
                {
                    switch (Filter?.ToLower())
                    {
                        case "success":
                            return _ => _.Status == "Success";
                        case "error":
                            return _ => _.Status == "Error";
                        case "unknownSender":
                            return _ => string.IsNullOrEmpty(_.DataCollector);
                        case "all":
                        default:
                            return _ => true;
                    }
                }
            }

            internal Func<ReportViewModel, IComparable> GetOrderByPredicate
            {
                get
                {
                    switch (SortBy?.ToLower())
                    {
                        case "status":
                            return _ => _.Status;
                        case "dataCollector":
                            return _ => _.DataCollector;
                        case "healthRisk":
                            return _ => _.HealthRisk;
                        case "femalesAges0To4":
                            return _ => _.FemalesUnder5;
                        case "femalesAgesOver4":
                            return _ => _.Females5OrOlder;
                        case "malesAges0To4":
                            return _ => _.MalesUnder5;
                        case "malesAgedOver4":
                            return _ => _.Males5OrOlder;
                        case "time":
                        default:
                            return _ => _.Date + _.Time;
                    }
                }
            }
        }
    }
}