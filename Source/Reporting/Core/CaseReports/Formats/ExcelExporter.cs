using System;
using System.Collections.Generic;
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
            worksheet.Cells[row,  1].Value = report.Timestamp.DateTime;
            worksheet.Cells[row, 13].Value = report.Message;

            if (report.DataCollectorId != DataCollectorId.NotSet)
            {
                worksheet.Cells[row,  3].Value = report.DataCollectorDisplayName;
                worksheet.Cells[row,  4].Value = report.DataCollectorRegion;
                worksheet.Cells[row,  5].Value = report.DataCollectorDistrict;
                worksheet.Cells[row,  6].Value = report.DataCollectorVillage;
            }
            else
            {
                worksheet.Cells[row,  3].Value = "Origin: "+report.Origin;
            }

            if (report.HealthRiskId != HealthRiskId.NotSet)
            {
                worksheet.Cells[row,  2].Value = "Success";
                worksheet.Cells[row,  7].Value = report.HealthRisk;
                worksheet.Cells[row,  8].Value = report.NumberOfMalesUnder5;
                worksheet.Cells[row,  9].Value = report.NumberOfMalesAged5AndOlder;
                worksheet.Cells[row, 10].Value = report.NumberOfFemalesUnder5;
                worksheet.Cells[row, 11].Value = report.NumberOfFemalesAged5AndOlder;
            }
            else
            {
                worksheet.Cells[row,  2].Value = "Error";
                worksheet.Cells[row, 14].Value = string.Join(", ", report.ParsingErrorMessage);
            }

            if (report.Location != Location.NotSet)
            {
                worksheet.Cells[row, 12].Value = $"{report.Location.Latitude.ToString("F4")}/{report.Location.Longitude.ToString("F4")}";
            }
        }

        void WriteHeaders(ExcelWorksheet worksheet)
        {
            worksheet.Cells["A1"].Value = "Time";
            worksheet.Cells["B1"].Value = "Status";
            worksheet.Cells["C1"].Value = "Datacollector";
            worksheet.Cells["D1"].Value = "Region";
            worksheet.Cells["E1"].Value = "District";
            worksheet.Cells["F1"].Value = "Village";
            worksheet.Cells["G1"].Value = "Health risk";
            worksheet.Cells["H1"].Value = "Males < 5";
            worksheet.Cells["I1"].Value = "Males ≥ 5";
            worksheet.Cells["J1"].Value = "Females < 5";
            worksheet.Cells["K1"].Value = "Females ≥ 5";
            worksheet.Cells["L1"].Value = "Location";
            worksheet.Cells["M1"].Value = "Message";
            worksheet.Cells["N1"].Value = "Errors";

            worksheet.Row(1).Style.Font.Bold = true;
            worksheet.Cells["A1:N1"].AutoFilter = true;
            worksheet.View.FreezePanes(2,1);
        }

        void SetColumnStyles(ExcelWorksheet worksheet)
        {
            worksheet.Column(1).Width = 20;
            worksheet.Column(3).Width = 30;
            worksheet.Column(4).Width = 20;
            worksheet.Column(5).Width = 20;
            worksheet.Column(6).Width = 20;
            worksheet.Column(7).Width = 15;
            worksheet.Column(8).Width = 12;
            worksheet.Column(9).Width = 12;
            worksheet.Column(10).Width = 12;
            worksheet.Column(11).Width = 12;
            worksheet.Column(12).Width = 15;
            worksheet.Column(13).Width = 15;
            worksheet.Column(14).Width = 20;

            worksheet.Column(1).Style.Numberformat.Format = "yyyy-MM-dd hh:mm";
        }
    }
}