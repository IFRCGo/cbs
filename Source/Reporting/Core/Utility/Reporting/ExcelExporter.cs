using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Read.Reporting.CaseReportsForListing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using ClosedXML.Excel;
using System.Globalization;

namespace Core.Utility
{
    public class ExcelExporter : IReportExporter
    {
        List<ReportColumn> columns;
        IXLWorkbook wb;
        IXLWorksheet ws;

        public ExcelExporter()
        {
            columns = new List<ReportColumn>();
            wb = new XLWorkbook();
            ws = wb.Worksheets.Add("Report " + DateTime.Now.ToString("yyyy-MM-dd HH꞉mm")); // NOTE: The colon is not a normal column, but a unicode because of excel rules

            columns.Add(new ReportColumn("A", ColumnType.Date, "Date"));
            columns.Add(new ReportColumn("B", ColumnType.Time, "Time"));
            columns.Add(new ReportColumn("C", ColumnType.EpiWeek, "Week"));
            columns.Add(new ReportColumn("D", ColumnType.Status, "Status"));
            columns.Add(new ReportColumn("E", ColumnType.DataCollector, "Data Collector"));
            columns.Add(new ReportColumn("F", ColumnType.Region, "Region"));
            columns.Add(new ReportColumn("G", ColumnType.District, "District"));
            columns.Add(new ReportColumn("H", ColumnType.Village, "Village"));
            columns.Add(new ReportColumn("I", ColumnType.HealthRisk, "Health risk"));
            columns.Add(new ReportColumn("J", ColumnType.MalesUnder5, "Males under 5"));
            columns.Add(new ReportColumn("K", ColumnType.Males5AndOlder, "Males 5 and older"));
            columns.Add(new ReportColumn("L", ColumnType.FemalesUnder5, "Females under 5"));
            columns.Add(new ReportColumn("M", ColumnType.Females5AndOlder, "Females 5 and older"));

            columns.Add(new ReportColumn("N", ColumnType.TotalUnder5, "Under 5 Total"));
            columns.Add(new ReportColumn("O", ColumnType.Total5OrOlder, "5 and older Total"));

            columns.Add(new ReportColumn("P", ColumnType.Lat, "Lat"));
            columns.Add(new ReportColumn("Q", ColumnType.Long, "Long"));
            columns.Add(new ReportColumn("R", ColumnType.Message, "Message"));
            columns.Add(new ReportColumn("S", ColumnType.ErrorMessage, "Errors"));
        }

        public bool WriteReports(IEnumerable<CaseReportForListing> reports, string[] fields, Stream stream)
        {
            uint rowIndex = 1;

            foreach (var column in columns)
            {
                ws.Cell(column.ExcelColumnName + rowIndex).Value = column.HeaderName;
                ws.Cell(column.ExcelColumnName + rowIndex).Style.Font.Bold = true;
            }

            foreach (var report in reports.OrderByDescending(e => e.Timestamp))
            {
                rowIndex++;

                GetCell(ColumnType.Date, rowIndex).Value = report.Timestamp;
                GetCell(ColumnType.Date, rowIndex).Style.DateFormat.Format = "dd/mm/yyy";

                GetCell(ColumnType.Time, rowIndex).Value = report.Timestamp;
                GetCell(ColumnType.Time, rowIndex).Style.DateFormat.Format = "HH:MM:ss";

                GetCell(ColumnType.EpiWeek, rowIndex).Value = GetEpiWeek(report.Timestamp.DateTime);

                GetCell(ColumnType.Status, rowIndex).Value = report.HealthRiskId != null ? "Success" : "Error";
                GetCell(ColumnType.DataCollector, rowIndex).Value = report.DataCollectorId != null ? report.DataCollectorDisplayName : "Origin: " + report.Origin;
                GetCell(ColumnType.Region, rowIndex).Value = report.DataCollectorId != null ? report.DataCollectorRegion : "";
                GetCell(ColumnType.District, rowIndex).Value = report.DataCollectorId != null ? report.DataCollectorDistrict : "";
                GetCell(ColumnType.Village, rowIndex).Value = report.DataCollectorId != null ? report.DataCollectorVillage : "";
                GetCell(ColumnType.Message, rowIndex).Value = report.Message;

                if (report.HealthRiskId != null)
                {
                    GetCell(ColumnType.HealthRisk, rowIndex).Value = report.HealthRisk;
                    GetCell(ColumnType.MalesUnder5, rowIndex).Value = report.NumberOfMalesUnder5;
                    GetCell(ColumnType.Males5AndOlder, rowIndex).Value = report.NumberOfMalesAged5AndOlder;
                    GetCell(ColumnType.FemalesUnder5, rowIndex).Value = report.NumberOfFemalesUnder5;
                    GetCell(ColumnType.Females5AndOlder, rowIndex).Value = report.NumberOfFemalesAged5AndOlder;

                    GetCell(ColumnType.Lat, rowIndex).Value = report.Location?.Latitude;
                    GetCell(ColumnType.Long, rowIndex).Value = report.Location?.Longitude;

                    GetCell(ColumnType.TotalUnder5, rowIndex).FormulaA1 = $"={GetCellAddress(ColumnType.MalesUnder5)}{rowIndex}+{GetCellAddress(ColumnType.FemalesUnder5)}{rowIndex}";
                    GetCell(ColumnType.Total5OrOlder, rowIndex).FormulaA1 = $"={GetCellAddress(ColumnType.Males5AndOlder)}{rowIndex}+{GetCellAddress(ColumnType.Females5AndOlder)}{rowIndex}";
                }
                else
                {
                    GetCell(ColumnType.ErrorMessage, rowIndex).Value = report.ParsingErrorMessage != null ? string.Join(".", report.ParsingErrorMessage) : "Health Risk Error";
                }
            }
            ws.Columns().AdjustToContents(); // Adjust width of all columns to content
            ws.RangeUsed().SetAutoFilter();
            wb.SaveAs(stream);
            return true;
        }

        public string GetFileExtension()
        {
            return ".xlsx";
        }

        public string GetMIMEType()
        {
            return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        }

        enum ColumnType
        {
            Date,
            Time,
            EpiWeek,
            Status,
            DataCollector,
            Region,
            District,
            Village,
            HealthRisk,
            MalesUnder5,
            Males5AndOlder,
            FemalesUnder5,
            Females5AndOlder,
            Lat,
            Long,
            Message,
            ErrorMessage,
            TotalUnder5,
            Total5OrOlder
        }


        private string GetCellAddress(ColumnType type)
        {
            return columns.Single(c => c.ColumnType == type).ExcelColumnName;
        }

        private IXLCell GetCell(ColumnType type, uint rowIndex)
        {
            var excelColumnName = GetCellAddress(type);
            return ws.Cell(excelColumnName + rowIndex);
        }

        public static int GetEpiWeek(DateTime time)
        {
            if (time.Month == 12 && time.Day > 28)
            {
                DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
                if (day >= DayOfWeek.Sunday && day <= DayOfWeek.Tuesday)
                {
                    time = time.AddDays(3);
                }
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
        }

        class ReportColumn
        {
            public string HeaderName { get; set; }
            public string ExcelColumnName { get; set; }
            public ColumnType ColumnType { get; set; }
            public ReportColumn(string excelColumn, ColumnType type, string header)
            {
                HeaderName = header;
                ColumnType = type;
                ExcelColumnName = excelColumn;
            }
        }
    }
}