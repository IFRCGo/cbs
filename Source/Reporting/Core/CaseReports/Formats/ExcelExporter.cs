using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Concepts.DataCollectors;
using Concepts.HealthRisks;
using OfficeOpenXml;
using Read.Reporting.CaseReportsForListing;

namespace Core.CaseReports.Formats
{
    public class ExcelExporter : ICanExportCaseReports
    {
        public string Format => "excel";

        public string MIMEType => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        public string FileExtension => ".xlsx";

        public void WriteReportsTo(IEnumerable<CaseReportForListing> reports, Stream stream)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("CaseReports");
                WriteMetadata(package.Workbook.Properties);

                SetColumnStyles(worksheet);
                WriteHeaders(worksheet);

                var row = 2;
                foreach (var report in reports)
                {
                    WriteRow(worksheet, row++, report);
                }

                package.SaveAs(stream);
            }
        }

        void WriteMetadata(OfficeProperties properties)
        {
            properties.Title = "Case reports";
            properties.Subject = $"Exported {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")} UTC";
            properties.Author = "Community Based Surveillance";
            properties.Company = "Red Cross";
            properties.Comments = "http://www.cbsrc.org";
        }

        void WriteRow(ExcelWorksheet worksheet, int row, CaseReportForListing report)
        {
            worksheet.Cells[row, 1].Value = report.Timestamp.DateTime;
            worksheet.Cells[row, 18].Value = report.Message;

            if (report.DataCollectorId != DataCollectorId.NotSet)
            {
                worksheet.Cells[row, 3].Value = report.DataCollectorDisplayName;
                worksheet.Cells[row, 4].Value = report.DataCollectorRegion;
                worksheet.Cells[row, 5].Value = report.DataCollectorDistrict;
                worksheet.Cells[row, 6].Value = report.DataCollectorVillage;
            }
            else
            {
                worksheet.Cells[row, 3].Value = "Origin: " + report.Origin;
            }

            if (report.HealthRiskId != HealthRiskId.NotSet)
            {
                worksheet.Cells[row, 2].Value = "Success";
                worksheet.Cells[row, 7].Value = report.HealthRisk;
                worksheet.Cells[row, 8].Value = report.NumberOfMalesUnder5;
                worksheet.Cells[row, 9].Value = report.NumberOfMalesAged5AndOlder;
                worksheet.Cells[row, 10].Value = report.NumberOfFemalesUnder5;
                worksheet.Cells[row, 11].Value = report.NumberOfFemalesAged5AndOlder;
                
                worksheet.Cells[row, 12].Value = report.NumberOfMalesUnder5 + report.NumberOfFemalesUnder5;
                worksheet.Cells[row, 13].Value = report.NumberOfMalesAged5AndOlder + report.NumberOfFemalesAged5AndOlder;
                worksheet.Cells[row, 14].Value = report.NumberOfMalesUnder5 + report.NumberOfMalesAged5AndOlder;
                worksheet.Cells[row, 15].Value = report.NumberOfFemalesUnder5 + report.NumberOfFemalesAged5AndOlder;
                worksheet.Cells[row, 16].Value = report.NumberOfMalesUnder5 + report.NumberOfMalesAged5AndOlder + report.NumberOfFemalesUnder5 + report.NumberOfFemalesAged5AndOlder;
            }
            else
            {
                worksheet.Cells[row, 2].Value = "Error";
                worksheet.Cells[row, 19].Value = string.Join(", ", report.ParsingErrorMessage);
            }

            if (report.Location != Location.NotSet)
            {
                worksheet.Cells[row, 17].Value = $"{report.Location.Latitude.ToString("F4")}/{report.Location.Longitude.ToString("F4")}";
            }
        }

        void WriteHeaders(ExcelWorksheet worksheet)
        {
            worksheet.Cells["A1"].Value = "Time";               // 1
            worksheet.Cells["B1"].Value = "Status";             // 2
            worksheet.Cells["C1"].Value = "Datacollector";      // 3
            worksheet.Cells["D1"].Value = "Region";             // 4
            worksheet.Cells["E1"].Value = "District";           // 5
            worksheet.Cells["F1"].Value = "Village";            // 6
            worksheet.Cells["G1"].Value = "Health risk";        // 7
            worksheet.Cells["H1"].Value = "Males under 5";      // 8
            worksheet.Cells["I1"].Value = "Males 5 or older";   // 9
            worksheet.Cells["J1"].Value = "Females under 5";    // 10
            worksheet.Cells["K1"].Value = "Females 5 or older"; // 11
            worksheet.Cells["L1"].Value = "Total under 5";      // 12
            worksheet.Cells["M1"].Value = "Total 5 or older";   // 13
            worksheet.Cells["N1"].Value = "Total females";      // 14
            worksheet.Cells["O1"].Value = "Total males";        // 15
            worksheet.Cells["P1"].Value = "Total";              // 16
            worksheet.Cells["Q1"].Value = "Location";           // 17
            worksheet.Cells["R1"].Value = "Message";            // 18
            worksheet.Cells["S1"].Value = "Errors";             // 19

            worksheet.Row(1).Style.Font.Bold = true;
            worksheet.Cells["A1:P1"].AutoFilter = true;
            worksheet.View.FreezePanes(2, 1);
        }

        void SetColumnStyles(ExcelWorksheet worksheet)
        {
            for(int i = 1; i<=7;i++) {
                worksheet.Column(i).Width = 25;
            }
            for(int i = 8; i<=16;i++) {
                worksheet.Column(i).Width = 18;
            }
            for(int i = 17; i<=19;i++) {
                worksheet.Column(i).Width = 25;
            }

            worksheet.Column(1).Style.Numberformat.Format = "yyyy-MM-dd hh:mm";
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

        public static int GetIsoWeek(DateTime time)
        {
            var cal = CultureInfo.InvariantCulture.Calendar;
            DayOfWeek day = cal.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return cal.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static int GetIsoYear(DateTime time)
        {
            if (time.Month == 12 && time.Day > 28)
            {
                DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
                if (day >= DayOfWeek.Sunday && day <= DayOfWeek.Tuesday)
                {
                    time = time.AddDays(3);
                }
            }
            return CultureInfo.InvariantCulture.Calendar.GetYear(time);
        }
    }
}