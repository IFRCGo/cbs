using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace Nyss.Web.Features.DataCollectors.Export.Formats
{
    public class ExcelExporter : ICanExportDataCollectors
    {
        public string Format => "excel";

        public string MIMEType => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        public string FileExtension => ".xlsx";

        public void WriteDataCollectorsTo(IEnumerable<DataCollectorViewModel> dataCollectors, Stream stream)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("DataCollectors");
                WriteMetadata(package.Workbook.Properties);

                SetColumnStyles(worksheet);
                WriteHeaders(worksheet);

                var row = 2;
                foreach (var dataCollector in dataCollectors)
                {
                    WriteRow(worksheet, row++, dataCollector);
                }

                package.SaveAs(stream);
            }
        }

        void WriteMetadata(OfficeProperties properties)
        {
            properties.Title = "Data collectors";
            properties.Subject = $"Exported {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")} UTC";
            properties.Author = "Community Based Surveillance";
            properties.Company = "Red Cross";
            properties.Comments = "http://www.cbsrc.org";
        }

        void WriteRow(ExcelWorksheet worksheet, int row, DataCollectorViewModel dataCollector)
        {
            worksheet.Cells[row, 1].Value = dataCollector.FullName;
            worksheet.Cells[row, 2].Value = dataCollector.DisplayName;
            worksheet.Cells[row, 3].Value = dataCollector.YearOfBirth;
            worksheet.Cells[row, 4].Value = dataCollector.Sex;
            worksheet.Cells[row, 5].Value = dataCollector.Language;
            worksheet.Cells[row, 6].Value = dataCollector.Latitude.ToString("0:0000");
            worksheet.Cells[row, 7].Value = dataCollector.Longitude.ToString("0.0000");
            worksheet.Cells[row, 8].Value = dataCollector.Region;
            worksheet.Cells[row, 9].Value = dataCollector.District;
            worksheet.Cells[row, 10].Value = dataCollector.Village;
            worksheet.Cells[row, 11].Value = dataCollector.Zone;
            worksheet.Cells[row, 12].Value = dataCollector.Supervisor;
            
            string phoneNumbers = string.Join(",", dataCollector.PhoneNumbers);
            worksheet.Cells[row, 13].Value = phoneNumbers;
        }

        void WriteHeaders(ExcelWorksheet worksheet)
        {
            worksheet.Cells["A1"].Value = "Full Name";          //  1
            worksheet.Cells["B1"].Value = "Display Name";       //  2
            worksheet.Cells["C1"].Value = "Year of Birth";      //  3
            worksheet.Cells["D1"].Value = "Sex";                //  4
            worksheet.Cells["E1"].Value = "Preferred Language"; //  5
            worksheet.Cells["F1"].Value = "Latitude";           //  6
            worksheet.Cells["G1"].Value = "Longitude";          //  7
            worksheet.Cells["H1"].Value = "Region";             //  8
            worksheet.Cells["I1"].Value = "District";           //  9
            worksheet.Cells["J1"].Value = "Village";            // 10
            worksheet.Cells["K1"].Value = "Zone";               // 11
            worksheet.Cells["L1"].Value = "Supervisor";         // 12
            worksheet.Cells["M1"].Value = "Phone Numbers";      // 13

            worksheet.Row(1).Style.Font.Bold = true;
            worksheet.Cells["A1:M1"].AutoFilter = true;
            worksheet.View.FreezePanes(2, 1);
        }

        void SetColumnStyles(ExcelWorksheet worksheet)
        {
            for (int i = 1; i <= 13; i++)
            {
                worksheet.Column(i).Width = 25;
            }
        }
    }
}
