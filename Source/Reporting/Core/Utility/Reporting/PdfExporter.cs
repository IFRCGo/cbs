// TODO fix
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using Read.CaseReportsForListing;
//using Concepts;
//using Concepts.DataCollector;

//namespace Core.Utility
//{
//    public class PdfExporter : IReportExporter
//    {
//        public string GetFileExtension()
//        {
//            return ".pdf";
//        }

//        public string GetMIMEType()
//        {
//            return "application/pdf";
//        }

//        public bool WriteReports(IEnumerable<CaseReportForListing> reports, string[] fields, Stream stream)
//        {
//            var nowString = DateTimeOffset.Now.ToString("yyyy-MMMM-dd");
//            var doc = new Document(PageSize.A4, 0f, 0f, 30f, 10f);

//            using (var writer = PdfWriter.GetInstance(doc, stream))
//            {
//                writer.CloseStream = false;

//                doc.AddAuthor("Cbs - Volunteer Reporting");
//                doc.AddCreator("Cbs - Volunteer Reporting");
//                doc.AddSubject("Case Reports " + nowString);
//                doc.AddTitle("Case Reports " + nowString);

//                doc.Open();
//                doc.NewPage();
//                if (reports.Any())
//                {
//                    AddCaseReportsToPdf(reports, doc, new string[] { });
//                }
//                else
//                {
//                    doc.Add(new Paragraph("No case reports were retrieved from the database"));
//                }

//                doc.Close();

//                writer.Flush();
//            }

//            return true;
//        }

//        private static void AddCaseReportsToPdf(IEnumerable<CaseReportForListing> caseReports, Document doc, string[] opts)
//        {
//            var table = new PdfPTable(9)
//            {
//                WidthPercentage = 100f,
//                PaddingTop = 10f,
//                HeaderRows = 1
//            };

//            table.SetWidths(new[] { 2.5f, 2f, 3f, 5f, 1f, 1f, 1f, 1f, 1.5f });

//            AddCaseReportFieldsToTable(table);

//            foreach (var caseReport in caseReports)
//            {
//                AddCaseReportDataToTable(table, caseReport);
//            }

//            doc.Add(table);

//        }

//        private static void AddCaseReportFieldsToTable(PdfPTable table)
//        {
//            table.AddCell("Time");
//            table.AddCell("Status");
//            table.AddCell("Datacollector");
//            table.AddCell("Healthrisk");
//            table.AddCell("M < 5");
//            table.AddCell("M >= 5"); //TODO: Greater equal symbol does not work in the pdf
//            table.AddCell("F < 5");
//            table.AddCell("F >= 5"); //TODO: Greater equal symbol does not work in the pdf
//            table.AddCell("Lat. Long.");
//        }

//        private static void AddCaseReportDataToTable(PdfPTable table, CaseReportForListing caseReport)
//        {
//            var time = caseReport.Timestamp.ToString("yyyy MMMM dd, HH:mm:ss");
//            var status = caseReport.HealthRiskId != null;

//            var dataCollector = caseReport.DataCollectorDisplayName != "Unknown"
//                ? caseReport.DataCollectorDisplayName
//                : "Origin: " + caseReport.Origin;

//            var latLong = caseReport.Location != null && caseReport.Location != Location.NotSet
//                ? caseReport.Location.ToString()
//                : "";

//            table.AddCell(time);
//            table.AddCell(status ? "Success" : "Error");
//            table.AddCell(dataCollector);

//            if (status)
//            {
//                var healthRisk = caseReport.HealthRisk;

//                var malesUnder5 = caseReport.NumberOfMalesUnder5.ToString();
//                var malesOver5 = caseReport.NumberOfMalesAged5AndOlder.ToString();

//                var femalesUnder5 = caseReport.NumberOfFemalesUnder5.ToString();

//                var femalesOver5 = caseReport.NumberOfFemalesAged5AndOlder.ToString();

//                table.AddCell(healthRisk);
//                table.AddCell(malesUnder5);
//                table.AddCell(malesOver5);
//                table.AddCell(femalesUnder5);
//                table.AddCell(femalesOver5);
//            }
//            else
//            {
//                var message = caseReport.Message;

//                var errorMessages = string.Join(", ", caseReport.ParsingErrorMessage != null ? String.Join(".", caseReport.ParsingErrorMessage) : "");

//                var cellText = message + "\nErrors: " + errorMessages;

//                var cell = new PdfPCell(new Phrase(cellText))
//                {
//                    Colspan = 5
//                };

//                table.AddCell(cell);
//            }

//            table.AddCell(latLong);
//        }
//    }
//}
