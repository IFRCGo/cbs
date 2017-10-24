using Read;
using Read.CaseReports;
using Read.HealthRisks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Concepts;

namespace Web.Models
{
    public class CaseReportForUnknownDataCollectorExpanded
    {
        public Guid Id { get; private set; }
        public HealthRisk HealthRisk { get; private set; }
        public int NumberOfFemalesOver5 { get; private set; }
        public int NumberOfFemalesUnder5 { get; private set; }
        public int NumberOfMalesOver5 { get; private set; }
        public int NumberOfMalesUnder5 { get; private set; }
        public DateTimeOffset Timestamp { get; private set; }
        public Location Location { get; private set; }

        public CaseReportForUnknownDataCollectorExpanded(CaseReportFromUnknownDataCollector caseReport, HealthRisk healthRisk)
        {
            Id = caseReport.Id;
            NumberOfFemalesOver5 = caseReport.NumberOfFemalesOver5;
            NumberOfFemalesUnder5 = caseReport.NumberOfFemalesUnder5;
            NumberOfMalesOver5 = caseReport.NumberOfMalesOver5;
            NumberOfMalesUnder5 = caseReport.NumberOfMalesUnder5;
            Timestamp = caseReport.Timestamp;
            Location = caseReport.Location;
            HealthRisk = healthRisk;
        }

    }
}
