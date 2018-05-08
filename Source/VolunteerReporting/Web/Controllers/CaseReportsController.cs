using System;
using System.Linq;
using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Read.CaseReports;
using Read.CaseReportsForListing;
using System.Threading.Tasks;
using Web.Utility;
using System.IO;
using System.Collections.Generic;
using Concepts;

using CaseReportForListing = Read.CaseReportsForListing.CaseReportForListing;

namespace Web.Controllers
{
    [Route("api/casereports")]
    public class CaseReportsController : Controller
    {
        private readonly ICaseReportsForListing _caseReports;
        private readonly ICaseReports _caseReportsObsolete;

        public CaseReportsController(ICaseReportsForListing caseReports, ICaseReports caseReportsObsolete)
        {
            _caseReports = caseReports;
            _caseReportsObsolete = caseReportsObsolete;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _caseReports.GetAllAsync());
        }

        private static Dictionary<string, IReportExporter> exporters = new Dictionary<string, IReportExporter>()
        {
            { "excel", new ExcelExporter() },
            { "csv", new CsvExporter() },
            { "pdf", new PdfExporter() },
        };

        [HttpGet("export")]
        public async Task<IActionResult> Export(string format = "excel", string[] fields = null, string filter = "all", string sortBy = "time", string order = "desc") {
            fields = fields ?? new string[] { "all" };

            //TODO: woksin: I think that having a parameter of some kind of datastructure that represents
            // the filtering and order by is the way to go(?)

            if (exporters.ContainsKey(format))
            {
                var exporter = exporters[format];

                var caseReports = await _caseReports.GetAllAsync() ?? new List<CaseReportForListing>();
                caseReports = ApplyFilteringAndSorting(caseReports, filter, sortBy, order);

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

        [HttpGet("obsolete")]
        [Obsolete]
        public async Task<IActionResult> GetObsolete()
        {
            return Ok(await _caseReportsObsolete.GetAllAsync());
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
                    return r => r.HealthRiskId == HealthRiskId.NotSet ||  r.HealthRisk == "Unknown";
                case "unknownSender":
                    return  r => r.DataCollectorId == DataCollectorId.NotSet || r.DataCollectorDisplayName == "Unknown";
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
