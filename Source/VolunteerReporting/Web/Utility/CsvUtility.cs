using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Concepts;
using Read.CaseReportsForListing;

namespace Web.Utility
{
    public static class CsvUtility
    {
        public static byte[] CreateCaseReportCsv(IEnumerable<CaseReportForListing> caseReports)
        {
            var sb = new StringBuilder();

            sb.Append(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\"",
                          "Time", "Status", "Data Collector", "Healthrisk", "Males < 5", "Males >= 5", "Females < 5",
                          "Females >= 5","Lat., Long.", "Message", "Errors") + Environment.NewLine);

            foreach (var caseReport in caseReports)
            {
                CaseReportToCsv(caseReport, sb);   
            }

            return Encoding.ASCII.GetBytes(sb.ToString());
        }

        private static void CaseReportToCsv(CaseReportForListing caseReport, StringBuilder sb)
        {
            //TODO: There could be trouble in the csv file if the case report message or errors contains " or any other characters that might confuse the csv.

            var time = caseReport.Timestamp.ToString("yyyy MMMM dd, hh:mm:ss tt");
            var status = !caseReport.ParsingErrorMessage.Any();

            var dataCollector = caseReport.DataCollectorDisplayName != "Unknown"
                ? caseReport.DataCollectorDisplayName
                : "Origin: " + caseReport.Origin;

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
                errors = string.Join(", ", caseReport.ParsingErrorMessage);
            }
            sb.Append(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\"",
                          time, status? "Success" : "Error", dataCollector, healthRisk, malesUnder5, malesOver5, femalesUnder5,
                          femalesOver5, latLong, message, errors) + Environment.NewLine);
        }
    }
}
