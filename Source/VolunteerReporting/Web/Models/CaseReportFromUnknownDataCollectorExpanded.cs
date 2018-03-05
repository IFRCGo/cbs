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
        public int NumberOfFemalesAgedOver4 { get; private set; }
        public int NumberOfFemalesAges0To4 { get; private set; }
        public int NumberOfMalesAgedOver4 { get; private set; }
        public int NumberOfMalesAges0To4 { get; private set; }
        public DateTimeOffset Timestamp { get; private set; }

        public CaseReportFromUnknownDataCollectorExpanded(CaseReportFromUnknownDataCollector caseReport, HealthRisk healthRisk)
        {
            Id = caseReport.Id;
            NumberOfFemalesAgedOver4 = caseReport.NumberOfFemalesAgedOver4;
            NumberOfFemalesAges0To4 = caseReport.NumberOfFemalesAges0To4;
            NumberOfMalesAgedOver4 = caseReport.NumberOfMalesAgedOver4;
            NumberOfMalesAges0To4 = caseReport.NumberOfMalesAges0To4;
            Timestamp = caseReport.Timestamp;
            HealthRisk = healthRisk;
        }

    }
}
