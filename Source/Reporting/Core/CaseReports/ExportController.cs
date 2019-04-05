using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Read.Reporting.CaseReportsForListing;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Concepts;
using Concepts.HealthRisks;
using Concepts.DataCollectors;
using Dolittle.Types;
using Dolittle.AspNetCore.Execution;
using Dolittle.Tenancy;
using System.Security.Claims;
using Dolittle.Security;
using Dolittle.DependencyInversion;

namespace Core.CaseReports
{
    [Route("case-reports/export")]
    public class CaseReportsController : Controller
    {
        readonly IExecutionContextConfigurator _executionContextConfigurator;
        readonly ITenantResolver _tenantResolver;
        readonly IInstancesOf<ICanExportCaseReports> _exporters;
        readonly FactoryFor<AllCaseReportsForListing> _allCaseReports;

        public CaseReportsController(
            IExecutionContextConfigurator executionContextConfigurator,
            ITenantResolver tenantResolver,
            IInstancesOf<ICanExportCaseReports> exporters,
            FactoryFor<AllCaseReportsForListing> allCaseReports
        )
        {
            _executionContextConfigurator = executionContextConfigurator;
            _tenantResolver = tenantResolver;
            _exporters = exporters;
            _allCaseReports = allCaseReports;
        }

        [HttpGet("json")]
        public IActionResult Get()
        {
            _executionContextConfigurator.ConfigureFor(_tenantResolver.Resolve(HttpContext.Request), Dolittle.Execution.CorrelationId.New(), ClaimsPrincipal.Current.ToClaims());
            
            return Ok(_allCaseReports().Query.ToList());
        }

        [HttpGet("download")]
        public IActionResult Export(DownloadParameters parameters)
        {
            _executionContextConfigurator.ConfigureFor(_tenantResolver.Resolve(HttpContext.Request), Dolittle.Execution.CorrelationId.New(), ClaimsPrincipal.Current.ToClaims());

            var exporter = _exporters.FirstOrDefault(_ => _.Format == parameters.Format);
            if (exporter != null)
            {
                var reports = _allCaseReports().Query;
                var filtered = reports.Where(parameters.FilterPredicate);
                var ordered = parameters.OrderDescending ? filtered.OrderByDescending(parameters.GetOrderByPredicate) : filtered.OrderBy(parameters.GetOrderByPredicate);

                var fileName = "case-reports-" + DateTimeOffset.UtcNow.ToString("yyyy-MMMM-dd") + exporter.FileExtension;

                var stream = new MemoryStream();
                exporter.WriteReportsTo(ordered, stream);
                stream.Position = 0;
                return File(stream, exporter.MIMEType, fileName);
            }
            else
            {
                return NotFound();
            }
        }

        public class DownloadParameters
        {
            public string Format { get; set; }
            public string Filter { get; set; }
            public string SortBy { get; set; }
            public string Order { get; set; }

            public bool OrderDescending
            {
                get => !Order?.ToLower()?.Equals("asc") ?? false;
            }
            public Func<CaseReportForListing, bool> FilterPredicate
            {
                get
                {
                    switch (Filter?.ToLower())
                    {
                        case "success":
                            return _ => _.HealthRiskId != HealthRiskId.NotSet && _.HealthRisk != "Unknown";
                        case "error":
                            return _ => _.HealthRiskId == HealthRiskId.NotSet || _.HealthRisk == "Unknown";
                        case "unknownSender":
                            return _ => _.DataCollectorId == DataCollectorId.NotSet || _.DataCollectorDisplayName == "Unknown";
                        case "all":
                        default:
                            return _ => true;
                    }
                }
            }
            public Func<CaseReportForListing, IComparable> GetOrderByPredicate
            {
                get
                {
                    switch (SortBy?.ToLower())
                    {
                        case "status":
                            return _ => _.Status;
                        case "dataCollector":
                            return _ => _.DataCollectorDisplayName;
                        case "healthRisk":
                            return _ => _.HealthRisk;
                        case "femalesAges0To4":
                            return _ => _.NumberOfFemalesUnder5;
                        case "femalesAgesOver4":
                            return _ => _.NumberOfFemalesAged5AndOlder;
                        case "malesAges0To4":
                            return _ => _.NumberOfMalesUnder5;
                        case "malesAgedOver4":
                            return _ => _.NumberOfMalesAged5AndOlder;
                        case "time":
                        default:
                            return _ => _.Timestamp;
                    }
                }
            }
        }
    }
}