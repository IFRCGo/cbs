using System;
using System.Linq;
using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Read.CaseReports;
using Read.CaseReportsForListing;
using Read.DataCollectors;
using Read.HealthRisks;
using System.Threading.Tasks;
using Web.Utility;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections.Generic;
using Concepts;
using DocumentFormat.OpenXml;

using CaseReportForListing = Read.CaseReportsForListing.CaseReportForListing;

namespace Web.Controllers
{
    [Route("api/casereports")]
    public class CaseReportsController : BaseController
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

        [HttpGet("export/pdf")]
        public async Task<IActionResult> PdfReport(string filter = "", string orderBy = "", string direction = "")
        {
            //TODO: I think that having a parameter of some kind of datastructure that represents
            // the filtering and order by is the way to go(?)
            

            var caseReports = await _caseReports.GetAllAsync() ?? new List<CaseReportForListing>();

            caseReports = ApplyFilteringAndSorting(caseReports, filter, orderBy, direction);

            var pdfBytes = PdfUtility.CreateCaseReportPdf(caseReports, new[] { "all" });

            return File(pdfBytes, "application/pdf",
                "casereports-" + DateTimeOffset.UtcNow.ToString("yyyy-MMMM-dd") + ".pdf");
            
        }

        [HttpGet("export/csv")]
        public async Task<IActionResult> CsvReport(string filter = "", string orderBy = "", string direction = "")
        {
            var caseReports = await _caseReports.GetAllAsync() ?? new List<CaseReportForListing>();

            caseReports = ApplyFilteringAndSorting(caseReports, filter, orderBy, direction);

            var csvBytes = CsvUtility.CreateCaseReportCsv(caseReports);

            return File(csvBytes, "text/csv", 
                "casereports-" + DateTimeOffset.UtcNow.ToString("yyyy-MMMM-dd") + ".csv");
        }

        [HttpGet("export/excel")]
        public async Task<IActionResult> Export(string filter = "", string orderBy = "", string direction = "")
        {
            //TODO: I think that having a parameter of some kind of datastructure that represents
            // the filtering and order by is the way to go(?)

            // Get all the case reports
            var reports = await _caseReports.GetAllAsync() ?? new List<CaseReportForListing>();

            reports = ApplyFilteringAndSorting(reports, filter, orderBy, direction);

            // Create the document in memory
            using (var stream = new MemoryStream())
            {
                var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook);
                WorkbookPart workbook = document.AddWorkbookPart();
                workbook.Workbook = new Workbook();
                Sheets sheets = document.WorkbookPart.Workbook.AppendChild(new Sheets());

                // Create a sheet in the document
                var data = new SheetData();
                WorksheetPart worksheet = workbook.AddNewPart<WorksheetPart>();
                worksheet.Worksheet = new Worksheet(data);
                Sheet sheet = new Sheet() { Id = document.WorkbookPart.GetIdOfPart(worksheet), SheetId = 1, Name = "Case Reports" };
                sheets.Append(sheet);


                uint rowIndex = 0;
                // Add some headers
                {
                    var row = new Row { RowIndex = ++rowIndex };
                    data.Append(row);

                    var headers = new SortedDictionary<string, string>
                    {
                        { "A", "Timestamp" },
                        { "B", "Status" },
                        { "C", "Data Collector" },
                        { "D", "Health Risk" },
                        { "E", "Males < 5" },
                        { "F", "Males ≥ 5" },
                        { "G", "Females < 5" },
                        { "H", "Females ≥ 5" },
                        { "I", "Lat. / Long." },
                        { "J", "Message" },
                        { "K", "Errors" }
                    };

                    foreach (var header in headers)
                    {
                        var cell = new Cell { CellReference = header.Key + rowIndex };
                        row.Append(cell);
                        cell.DataType = new EnumValue<CellValues>(CellValues.String);
                        cell.CellValue = new CellValue(header.Value);
                    }
                }

                // Insert data
                foreach (var report in reports.OrderByDescending(e => e.Timestamp))
                {
                    var row = new Row { RowIndex = ++rowIndex };
                    data.Append(row);

                    var timestamp = new Cell { CellReference = "A" + rowIndex };
                    row.Append(timestamp);
                    timestamp.DataType = new EnumValue<CellValues>(CellValues.String);
                    timestamp.CellValue = new CellValue(report.Timestamp.ToString("yyyy MMMM dd, hh:mm:ss tt"));

                    var status = new Cell { CellReference = "B" + rowIndex };
                    row.Append(status);
                    status.DataType = new EnumValue<CellValues>(CellValues.String);

                    var origin = new Cell { CellReference = "C" + rowIndex };
                    row.Append(origin);
                    origin.DataType = new EnumValue<CellValues>(CellValues.String);
                    origin.CellValue = new CellValue(report.DataCollectorId != null ? report.DataCollectorDisplayName : "Origin: " + report.Origin);

                    var healthrisk = new Cell { CellReference = "D" + rowIndex };
                    row.Append(healthrisk);
                    healthrisk.DataType = new EnumValue<CellValues>(CellValues.String);

                    var malesUnder5 = new Cell { CellReference = "E" + rowIndex };
                    row.Append(malesUnder5);
                    malesUnder5.DataType = new EnumValue<CellValues>(CellValues.Number);

                    var malesOver5 = new Cell { CellReference = "F" + rowIndex };
                    row.Append(malesOver5);
                    malesOver5.DataType = new EnumValue<CellValues>(CellValues.Number);

                    var femalesUnder5 = new Cell { CellReference = "G" + rowIndex };
                    row.Append(femalesUnder5);
                    femalesUnder5.DataType = new EnumValue<CellValues>(CellValues.Number);

                    var femalesOver5 = new Cell { CellReference = "H" + rowIndex };
                    row.Append(femalesOver5);
                    femalesOver5.DataType = new EnumValue<CellValues>(CellValues.Number);

                    var location = new Cell { CellReference = "I" + rowIndex };
                    row.Append(location);
                    location.DataType = new EnumValue<CellValues>(CellValues.String);
                    location.CellValue = new CellValue(report.Location != null ? report.Location.Latitude + "/" + report.Location.Longitude : "");

                    var message = new Cell { CellReference = "J" + rowIndex };
                    row.Append(message);
                    message.DataType = new EnumValue<CellValues>(CellValues.String);
                    message.CellValue = new CellValue(report.Message);

                    var error = new Cell { CellReference = "K" + rowIndex };
                    row.Append(error);
                    error.DataType = new EnumValue<CellValues>(CellValues.String);

                    if (report.HealthRiskId != null)
                    {
                        status.CellValue = new CellValue("Success");
                        healthrisk.CellValue = new CellValue(report.HealthRisk);
                        malesUnder5.CellValue = new CellValue(report.NumberOfMalesUnder5.ToString());
                        malesOver5.CellValue = new CellValue(report.NumberOfMalesAged5AndOlder.ToString());
                        femalesUnder5.CellValue = new CellValue(report.NumberOfFemalesUnder5.ToString());
                        femalesOver5.CellValue = new CellValue(report.NumberOfFemalesAged5AndOlder.ToString());
                        error.CellValue = new CellValue("");
                    }
                    else
                    {
                        status.CellValue = new CellValue("Error");
                        healthrisk.CellValue = new CellValue("");
                        malesUnder5.CellValue = new CellValue("");
                        malesOver5.CellValue = new CellValue("");
                        femalesUnder5.CellValue = new CellValue("");
                        femalesOver5.CellValue = new CellValue("");
                        error.CellValue = new CellValue(report.ParsingErrorMessage != null ? String.Join(".", report.ParsingErrorMessage) : "");
                    }
                }

                // Save the document in memory, and serve to client
                workbook.Workbook.Save();
                document.Close();
                stream.Seek(0, SeekOrigin.Begin);

                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "casereports-" + DateTimeOffset.UtcNow.ToString("yyyy-MMMM-dd") + ".xlsx");
            }
        }

        [HttpGet("obsolete")]
        [Obsolete]
        public async Task<IActionResult> GetObsolete()
        {
            return Ok(await _caseReportsObsolete.GetAllAsync());
        }

        [Obsolete]
        [HttpGet("getlimitlast")] // Used as api/casereports/getlimitlast?limit=..
        public async Task<IActionResult> GetLimitLast(int limit)
        {
            return Ok(await _caseReports.GetLimitAsync(limit, true));
        }
        [Obsolete]
        [HttpGet("getlimitfirst")] // Used as api/casereports/getlimitfirst?limit=..
        public async Task<IActionResult> GetLimitFirst(int limit)
        {
            return Ok(await _caseReports.GetLimitAsync(limit, false));
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
                case "unknown_sender":
                    return  r => r.DataCollectorId == DataCollectorId.NotSet || r.DataCollectorDisplayName == "Unknown";
                default:
                    return _ => true;
            }
        }

        private Func<CaseReportForListing, IComparable> GetOrderByPredicate(string filter)
        {
            switch (filter)
            {
                case "time":
                    return e => e.Timestamp;
                case "females_under":
                    return r => r.NumberOfFemalesUnder5;
                case "females_over":
                    return r => r.NumberOfFemalesAged5AndOlder;
                case "males_under":
                    return r => r.NumberOfMalesUnder5;
                case "males_over":
                    return r => r.NumberOfMalesAged5AndOlder;
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
                    return true;
                default:
                    return true;
            }
        }
    }
}
