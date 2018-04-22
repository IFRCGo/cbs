using System;
using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Read.CaseReports;
using Read.CaseReportsForListing;
using Read.DataCollectors;
using Read.HealthRisks;
using System.Threading.Tasks;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections.Generic;
using DocumentFormat.OpenXml;

namespace Web.Controllers
{
    [Route("api/casereports")]
    public class CaseReportsController : BaseController
    {
        private readonly ICaseReportsForListing _caseReports;
        private readonly ICaseReports _caseReportsObsolete;
        private readonly IHealthRisks _healthRisks;
        private readonly IDataCollectors _dataCollectors;

        public CaseReportsController(ICaseReportsForListing caseReports, ICaseReports caseReportsObsolete, IHealthRisks healthRisks, IDataCollectors dataCollectors)
        {
            _caseReports = caseReports;
            _caseReportsObsolete = caseReportsObsolete;
            _healthRisks = healthRisks;
            _dataCollectors = dataCollectors;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _caseReports.GetAllAsync());
        }

        [HttpGet("obsolete")]
        [Obsolete]
        public async Task<IActionResult> GetObsolete()
        {
            return Ok(await _caseReportsObsolete.GetAllAsync());
        }

        [HttpGet("getlimitlast")] // Used as api/casereports/getlimitlast?limit=..
        public async Task<IActionResult> GetLimitLast(int limit)
        {
            return Ok(await _caseReports.GetLimitAsync(limit, true));
        }

        [HttpGet("getlimitfirst")] // Used as api/casereports/getlimitfirst?limit=..
        public async Task<IActionResult> GetLimitFirst(int limit)
        {
            return Ok(await _caseReports.GetLimitAsync(limit, false));
        }

        [HttpGet("export")]
        public async Task<IActionResult> Export()
        {
            // Get all the case reports
            IEnumerable<CaseReportForListing> reports = await _caseReports.GetAllAsync();

            // Create the document in memory
            MemoryStream stream = new MemoryStream();
            SpreadsheetDocument document = SpreadsheetDocument.Create(stream, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook);
            WorkbookPart workbook = document.AddWorkbookPart();
            workbook.Workbook = new Workbook();
            Sheets sheets = document.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

            // Create a sheet in the document
            SheetData data = new SheetData();
            WorksheetPart worksheet = workbook.AddNewPart<WorksheetPart>();
            worksheet.Worksheet = new Worksheet(data);
            Sheet sheet = new Sheet() { Id = document.WorkbookPart.GetIdOfPart(worksheet), SheetId = 1, Name = "Case Reports" };
            sheets.Append(sheet);

            
            uint rowIndex = 0;
            // Add some headers
            {
                Row row = new Row() { RowIndex = ++rowIndex };
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
                    Cell cell = new Cell() { CellReference = header.Key + rowIndex };
                    row.Append(cell);
                    cell.DataType = new EnumValue<CellValues>(CellValues.String);
                    cell.CellValue = new CellValue(header.Value);
                }
            }

            // Insert data
            foreach (CaseReportForListing report in reports)
            {
                Row row = new Row() { RowIndex = ++rowIndex };
                data.Append(row);

                Cell timestamp = new Cell() { CellReference = "A" + rowIndex };
                row.Append(timestamp);
                timestamp.DataType = new EnumValue<CellValues>(CellValues.String);
                timestamp.CellValue = new CellValue(report.Timestamp.ToString());

                Cell status = new Cell() { CellReference = "B" + rowIndex };
                row.Append(status);
                status.DataType = new EnumValue<CellValues>(CellValues.String);
                
                Cell origin = new Cell() { CellReference = "C" + rowIndex };
                row.Append(origin);
                origin.DataType = new EnumValue<CellValues>(CellValues.String);
                origin.CellValue = new CellValue(report.DataCollectorId != null ? report.DataCollectorDisplayName : "Origin: " + report.Origin);

                Cell healthrisk = new Cell() { CellReference = "D" + rowIndex };
                row.Append(healthrisk);
                healthrisk.DataType = new EnumValue<CellValues>(CellValues.String);

                Cell malesUnder5 = new Cell() { CellReference = "E" + rowIndex };
                row.Append(malesUnder5);
                malesUnder5.DataType = new EnumValue<CellValues>(CellValues.Number);

                Cell malesOver5 = new Cell() { CellReference = "F" + rowIndex };
                row.Append(malesOver5);
                malesOver5.DataType = new EnumValue<CellValues>(CellValues.Number);

                Cell femalesUnder5 = new Cell() { CellReference = "G" + rowIndex };
                row.Append(femalesUnder5);
                femalesUnder5.DataType = new EnumValue<CellValues>(CellValues.Number);

                Cell femalesOver5 = new Cell() { CellReference = "H" + rowIndex };
                row.Append(femalesOver5);
                femalesOver5.DataType = new EnumValue<CellValues>(CellValues.Number);

                Cell location = new Cell() { CellReference = "I" + rowIndex };
                row.Append(location);
                location.DataType = new EnumValue<CellValues>(CellValues.String);
                location.CellValue = new CellValue(report.Location != null ? report.Location.Latitude+"/"+report.Location.Longitude : "");

                Cell message = new Cell() { CellReference = "J" + rowIndex };
                row.Append(message);
                message.DataType = new EnumValue<CellValues>(CellValues.String);
                message.CellValue = new CellValue(report.Message);

                Cell error = new Cell() { CellReference = "K" + rowIndex };
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

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "casereports.xlsx");
        }

    }
}
