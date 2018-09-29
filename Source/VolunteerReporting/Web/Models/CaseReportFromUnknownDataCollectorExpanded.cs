using Read.CaseReports;
using Read.HealthRisks;
using System;

namespace Web.Models
{
    //TODO: Don't really need this anymore because of CaseReportForListing?
    public class CaseReportFromUnknownDataCollectorExpanded
    {
        public Guid Id { get; private set; }
        public HealthRisk HealthRisk { get; private set; }
        public int NumberOfFemalesAged5AndOlder { get; private set; }
        public int NumberOfFemalesUnder5 { get; private set; }
        public int NumberOfMalesAged5AndOlder { get; private set; }
        public int NumberOfMalesUnder5 { get; private set; }
        public DateTimeOffset Timestamp { get; private set; }

        public CaseReportFromUnknownDataCollectorExpanded(CaseReportFromUnknownDataCollector caseReport, HealthRisk healthRisk)
        {
            Id = caseReport.Id;
            NumberOfFemalesAged5AndOlder = caseReport.NumberOfFemalesAged5AndOlder;
            NumberOfFemalesUnder5 = caseReport.NumberOfFemalesUnder5;
            NumberOfMalesAged5AndOlder = caseReport.NumberOfMalesAged5AndOlder;
            NumberOfMalesUnder5 = caseReport.NumberOfMalesUnder5;
            Timestamp = caseReport.Timestamp;
            HealthRisk = healthRisk;
        }

    }
}
