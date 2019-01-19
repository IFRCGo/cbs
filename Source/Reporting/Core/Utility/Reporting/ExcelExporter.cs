using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Read.Reporting.CaseReportsForListing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;

namespace Core.Utility
{
    public class ExcelExporter : IReportExporter
    {
        public string GetFileExtension()
        {
            return ".xlsx";
        }

        public string GetMIMEType()
        {
            return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        }

        public bool WriteReports(IEnumerable<CaseReportForListing> reports, string[] fields, Stream stream)
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
                        { "A", "Date" },
                        { "B", "Time"},
                        { "C", "Status" },
                        { "D", "Data Collector" },
                        { "E", "Region" },
                        { "F", "District" },
                        { "G", "Village" },
                        { "H", "Health Risk" },
                        { "I", "Males < 5" },
                        { "J", "Males ≥ 5" },
                        { "K", "Females < 5" },
                        { "L", "Females ≥ 5" },
                        { "M", "Lat. / Long." },
                        { "N", "Message" },
                        { "O", "Errors" }
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

                var date = new Cell { CellReference = "A" + rowIndex };
                row.Append(date);
                date.DataType = new EnumValue<CellValues>(CellValues.Date);
                date.CellValue = new CellValue(report.Timestamp.ToString("yyyy MMMM dd"));

                var timestamp = new Cell { CellReference = "B" + rowIndex };
                row.Append(timestamp);
                timestamp.DataType = new EnumValue<CellValues>(CellValues.String);
                timestamp.CellValue = new CellValue(report.Timestamp.ToString("HH:mm:ss"));

                var status = new Cell { CellReference = "C" + rowIndex };
                row.Append(status);
                status.DataType = new EnumValue<CellValues>(CellValues.String);

                var origin = new Cell { CellReference = "D" + rowIndex };
                row.Append(origin);
                origin.DataType = new EnumValue<CellValues>(CellValues.String);
                origin.CellValue = new CellValue(report.DataCollectorId != null ? report.DataCollectorDisplayName : "Origin: " + report.Origin);

                var region = new Cell { CellReference = "E" + rowIndex };
                row.Append(region);
                region.DataType = new EnumValue<CellValues>(CellValues.String);
                region.CellValue = new CellValue(report.DataCollectorId != null ? report.DataCollectorRegion : "");

                var district = new Cell { CellReference = "F" + rowIndex };
                row.Append(district);
                district.DataType = new EnumValue<CellValues>(CellValues.String);
                district.CellValue = new CellValue(report.DataCollectorId != null ? report.DataCollectorDistrict : "");

                var village = new Cell { CellReference = "G" + rowIndex };
                row.Append(village);
                village.DataType = new EnumValue<CellValues>(CellValues.String);
                village.CellValue = new CellValue(report.DataCollectorId != null ? report.DataCollectorVillage : "");

                var healthrisk = new Cell { CellReference = "H" + rowIndex };
                row.Append(healthrisk);
                healthrisk.DataType = new EnumValue<CellValues>(CellValues.String);

                var malesUnder5 = new Cell { CellReference = "I" + rowIndex };
                row.Append(malesUnder5);
                malesUnder5.DataType = new EnumValue<CellValues>(CellValues.Number);

                var malesOver5 = new Cell { CellReference = "J" + rowIndex };
                row.Append(malesOver5);
                malesOver5.DataType = new EnumValue<CellValues>(CellValues.Number);

                var femalesUnder5 = new Cell { CellReference = "K" + rowIndex };
                row.Append(femalesUnder5);
                femalesUnder5.DataType = new EnumValue<CellValues>(CellValues.Number);

                var femalesOver5 = new Cell { CellReference = "L" + rowIndex };
                row.Append(femalesOver5);
                femalesOver5.DataType = new EnumValue<CellValues>(CellValues.Number);

                var location = new Cell { CellReference = "M" + rowIndex };
                row.Append(location);
                location.DataType = new EnumValue<CellValues>(CellValues.String);
                location.CellValue = new CellValue(report.Location != null ? report.Location.Latitude + "/" + report.Location.Longitude : "");

                var message = new Cell { CellReference = "N" + rowIndex };
                row.Append(message);
                message.DataType = new EnumValue<CellValues>(CellValues.String);
                message.CellValue = new CellValue(report.Message);

                var error = new Cell { CellReference = "O" + rowIndex };
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
                    error.CellValue = new CellValue(report.ParsingErrorMessage != null ? string.Join(".", report.ParsingErrorMessage) : "");
                }
            }

            // Save the document in memory, and serve to client
            workbook.Workbook.Save();
            document.Close();
            return true;
        }
    }
}
