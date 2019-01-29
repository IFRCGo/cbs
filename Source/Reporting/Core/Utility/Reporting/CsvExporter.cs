using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Concepts;
using Concepts.DataCollectors;
using Read.Reporting.CaseReportsForListing;

namespace Core.Utility
{
    public class CsvExporter : IReportExporter
    {
        public string GetFileExtension()
        {
            return ".csv";
        }

        public string GetMIMEType()
        {
            return "text/csv";
        }

        public bool WriteReports(IEnumerable<CaseReportForListing> reports, string[] fields, Stream stream)
        {
            var writer = new StreamWriter(stream, Encoding.UTF8);

            writer.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\",\"{14}\"",
                          "Date", "Time", "Status", "Data Collector", "Region", "District", "Village", "Healthrisk", "Males < 5", "Males >= 5", "Females < 5",
                          "Females >= 5", "Lat., Long.", "Message", "Errors"));

            foreach (var caseReport in reports)
            {
                var date = caseReport.Timestamp.ToString("yyyy MMMM dd");
                var time = caseReport.Timestamp.ToString("HH:mm:ss");
                var status = caseReport.HealthRiskId != null;

                var dataCollector = caseReport.DataCollectorDisplayName != "Unknown"
                    ? caseReport.DataCollectorDisplayName
                    : "Origin: " + caseReport.Origin;

                var region = caseReport.DataCollectorDisplayName != "Unknown"
                    ? caseReport.DataCollectorRegion
                    : "";

                var district = caseReport.DataCollectorDisplayName != "Unknown"
                    ? caseReport.DataCollectorDistrict
                    : "";

                var village = caseReport.DataCollectorDisplayName != "Unknown"
                    ? caseReport.DataCollectorVillage
                    : "";

                var latLong = caseReport.Location != null && caseReport.Location != Location.NotSet
                    ? caseReport.Location.ToString()
                    : "";

                var healthRisk = "";

                var malesUnder5 = "";
                var malesOver5 = "";

                var femalesUnder5 = "";
                var femalesOver5 = "";

                var message = caseReport.Message;

                var errors = "";


                if (status)
                {
                    healthRisk = caseReport.HealthRisk;

                    malesUnder5 = caseReport.NumberOfMalesUnder5.ToString();
                    malesOver5 = caseReport.NumberOfMalesAged5AndOlder.ToString();

                    femalesUnder5 = caseReport.NumberOfFemalesUnder5.ToString();

                    femalesOver5 = caseReport.NumberOfFemalesAged5AndOlder.ToString();

                }
                else
                {
                    errors = string.Join(", ", caseReport.ParsingErrorMessage != null ? String.Join(".", caseReport.ParsingErrorMessage) : "");
                }
                writer.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\",\"{14}\"",
                              date, time, status ? "Success" : "Error", dataCollector, region, district, village, healthRisk, malesUnder5, malesOver5, femalesUnder5,
                              femalesOver5, latLong, message, errors));
            }

            writer.Flush();
            return true;
        }
    }
}
