using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Microsoft.CodeAnalysis;
using Nyss.Web.Features.Report;
using OfficeOpenXml;

namespace Core.CaseReports.Formats
{
    public class ExcelExporter : ICanExportCaseReports
    {
        public string Format => "excel";

        public string MIMEType => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        public string FileExtension => ".xlsx";

        public void WriteReportsTo(IEnumerable<ReportViewModel> reports, Stream stream)
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

        void WriteRow(ExcelWorksheet worksheet, int row, ReportViewModel report)
        {
            worksheet.Cells[row, 1].Value = report.Date;
            worksheet.Cells[row, 2].Value = report.Time;

            worksheet.Cells[row, 3].Value = report.Status;

            worksheet.Cells[row, 4].Value = report.DataCollector;
            worksheet.Cells[row, 5].Value = report.Region;
            worksheet.Cells[row, 6].Value = report.District;
            worksheet.Cells[row, 7].Value = report.Village;

            worksheet.Cells[row, 8].Value = report.HealthRisk;
            worksheet.Cells[row, 9].Value = report.MalesUnder5;
            worksheet.Cells[row, 10].Value = report.Males5OrOlder;
            worksheet.Cells[row, 11].Value = report.FemalesUnder5;
            worksheet.Cells[row, 12].Value = report.Females5OrOlder;

            worksheet.Cells[row, 13].Value = report.TotalUnder5;
            worksheet.Cells[row, 14].Value = report.Total5OrOlder;
            worksheet.Cells[row, 15].Value = report.TotalFemales;
            worksheet.Cells[row, 16].Value = report.TotalMales;
            worksheet.Cells[row, 17].Value = report.Total;

            worksheet.Cells[row, 18].Value = report.Location;

            worksheet.Cells[row, 19].Value = report.Message;
            
            worksheet.Cells[row, 20].Value = report.Errors;

            worksheet.Cells[row, 21].Value = report.IsoYear;
            worksheet.Cells[row, 22].Value = report.IsoWeek;
            worksheet.Cells[row, 23].Value = report.IsoYearIsoWeek;
        }

        void WriteHeaders(ExcelWorksheet worksheet)
        {
            worksheet.Cells["A1"].Value = "Date";               // 1
            worksheet.Cells["B1"].Value = "Time";               // 2
            worksheet.Cells["C1"].Value = "Status";             // 3
            worksheet.Cells["D1"].Value = "Datacollector";      // 4
            worksheet.Cells["E1"].Value = "Region";             // 5
            worksheet.Cells["F1"].Value = "District";           // 6
            worksheet.Cells["G1"].Value = "Village";            // 7
            worksheet.Cells["H1"].Value = "Health risk";        // 8
            worksheet.Cells["I1"].Value = "Males under 5";      // 9
            worksheet.Cells["J1"].Value = "Males 5 or older";   // 10
            worksheet.Cells["K1"].Value = "Females under 5";    // 11
            worksheet.Cells["L1"].Value = "Females 5 or older"; // 12
            worksheet.Cells["M1"].Value = "Total under 5";      // 13
            worksheet.Cells["N1"].Value = "Total 5 or older";   // 14
            worksheet.Cells["O1"].Value = "Total females";      // 15
            worksheet.Cells["P1"].Value = "Total males";        // 16
            worksheet.Cells["Q1"].Value = "Total";              // 17
            worksheet.Cells["R1"].Value = "Location";           // 18
            worksheet.Cells["S1"].Value = "Message";            // 19
            worksheet.Cells["T1"].Value = "Errors";             // 20
            worksheet.Cells["U1"].Value = "ISOyear";            // 21
            worksheet.Cells["V1"].Value = "ISOweek";            // 22
            worksheet.Cells["W1"].Value = "ISOyear-ISOweek";    // 23

            worksheet.Row(1).Style.Font.Bold = true;
            worksheet.Cells["A1:P1"].AutoFilter = true;
            worksheet.View.FreezePanes(2, 1);
        }

        void SetColumnStyles(ExcelWorksheet worksheet)
        {
            for (int i = 1; i <= 7; i++)
            {
                worksheet.Column(i).Width = 25;
            }
            for (int i = 8; i <= 16; i++)
            {
                worksheet.Column(i).Width = 18;
            }
            for (int i = 17; i <= 19; i++)
            {
                worksheet.Column(i).Width = 25;
            }

            worksheet.Column(1).Style.Numberformat.Format = "dd/MM/yyyy";
            worksheet.Column(2).Style.Numberformat.Format = "HH:mm";
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