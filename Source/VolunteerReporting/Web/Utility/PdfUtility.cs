
using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Read.CaseReportsForListing;

namespace Web.Utility
{
    public static class PdfUtility
    {
        public static byte[] CreateCaseReportPdf(IList<CaseReportForListing> caseReports, string[] opts)
        {
            using (var stream = new MemoryStream())
            {
                var doc = new Document(PageSize.A4, 30f, 30f, 30f, 30f);

                using (var writer = PdfWriter.GetInstance(doc, stream))
                {
                    writer.CloseStream = false;

                    doc.AddAuthor("Sindre");
                    doc.AddCreator("Application");
                    doc.AddSubject("PDF test");
                    doc.AddTitle("Title");

                    doc.Open();

                    doc.Add(new Paragraph("hey"));
                    doc.Add(new Paragraph("hey"));
                    doc.Add(new Paragraph("hey"));
                    doc.Add(new Paragraph("Hello World"));
                    doc.Add(new Paragraph(DateTime.Now.ToString()));

                    doc.Close();

                    writer.Flush();
                }
                
                stream.Seek(0, SeekOrigin.Begin);

                return stream.ToArray();
            }
        }

        private static void AddCaseReportsToPdf(IList<CaseReportForListing> caseReports, Document doc, string[] opts)
        {
            var table = new PdfPTable(3);


        }
    }
}