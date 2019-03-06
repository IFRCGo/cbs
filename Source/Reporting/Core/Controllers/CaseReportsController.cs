using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Read.Reporting.CaseReportsForListing;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Concepts;
using Core.Utility;
using Concepts.HealthRisks;
using Concepts.DataCollectors;
using Dolittle.AspNetCore.Execution;
using Dolittle.Tenancy;
using System.Security.Claims;
using Dolittle.Security;

namespace Web.Controllers
{
    [Route("api/casereportexport")]
    public class CaseReportsExportController : Controller
    {
        private readonly AllCaseReportsForListing _caseReports;
        private readonly IExecutionContextConfigurator _executionContextConfigurator;
        private readonly ITenantResolver _tenantResolver;

        public CaseReportsExportController(AllCaseReportsForListing caseReports,
            IExecutionContextConfigurator executionContextConfigurator,
            ITenantResolver tenantResolver)
        {
            _caseReports = caseReports;
            _executionContextConfigurator = executionContextConfigurator;
            _tenantResolver = tenantResolver;
        }

        private static Dictionary<string, IReportExporter> exporters = 
            new Dictionary<string, IReportExporter>()
            {
                { "excel", new ExcelExporter() },
                { "csv", new CsvExporter() }
            };

        [HttpGet("export")]
        public IActionResult Export(string format = "excel", string[] fields = null, string filter = "all", string sortBy = "time", string order = "desc")
        {
            _executionContextConfigurator.ConfigureFor(_tenantResolver.Resolve(HttpContext.Request), Dolittle.Execution.CorrelationId.New(), ClaimsPrincipal.Current.ToClaims());

            fields = fields ?? new string[] { "all" };

            if (exporters.ContainsKey(format))
            {
                var exporter = exporters[format];

                var caseReports = _caseReports.Query.ToList() ?? new List<CaseReportForListing>();
                caseReports = ApplyFilteringAndSorting(caseReports, filter, sortBy, order).ToList();

                var stream = new MemoryStream();
                var result = exporter.WriteReports(caseReports, fields, stream);

                if (result)
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, exporter.GetMIMEType(), "casereports-" + DateTimeOffset.UtcNow.ToString("yyyy-MMMM-dd") + exporter.GetFileExtension());
                }
                else
                {
                    stream.Close();
                    return StatusCode(500);
                }
            }
            else
            {
                return NotFound();
            }
        }

        private IEnumerable<CaseReportForListing> ApplyFilteringAndSorting(
            IEnumerable<CaseReportForListing> caseReports, string filter, string orderBy, string direction)
        {
            return SortDesc(direction)
                ? caseReports.Where(GetFilterPredicate(filter)).OrderByDescending(GetOrderByPredicate(orderBy))
                : caseReports.Where(GetFilterPredicate(filter)).OrderBy(GetOrderByPredicate(orderBy));
        }

        private Func<CaseReportForListing, bool> GetFilterPredicate(string filter)
        {
            switch (filter)
            {
                case "all":
                    return _ => true;
                case "success":
                    return r => r.HealthRiskId != HealthRiskId.NotSet && r.HealthRisk != "Unknown";
                case "error":
                    return r => r.HealthRiskId == HealthRiskId.NotSet || r.HealthRisk == "Unknown";
                case "unknownSender":
                    return r => r.DataCollectorId == DataCollectorId.NotSet || r.DataCollectorDisplayName == "Unknown";
                default:
                    return _ => true;
            }
        }

        private Func<CaseReportForListing, IComparable> GetOrderByPredicate(string filter)
        {
            switch (filter)
            {
                case "status":
                    return r => r.Status;
                case "dataCollector":
                    return r => r.DataCollectorDisplayName;
                case "healthRisk":
                    return r => r.HealthRisk;
                case "femalesAges0To4":
                    return r => r.NumberOfFemalesUnder5;
                case "femalesAgesOver4":
                    return r => r.NumberOfFemalesAged5AndOlder;
                case "malesAges0To4":
                    return r => r.NumberOfMalesUnder5;
                case "malesAgedOver4":
                    return r => r.NumberOfMalesAged5AndOlder;
                case "time":
                default:
                    return e => e.Timestamp;
            }
        }

        private bool SortDesc(string direction)
        {
            switch (direction)
            {
                case "asc":
                    return false;
                case "desc":
                default:
                    return true;
            }
        }
    }
}