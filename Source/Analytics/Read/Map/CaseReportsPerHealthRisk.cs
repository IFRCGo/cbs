using System.Collections.Generic;
using Concepts.HealthRisks;

namespace Read.Map
{
    public class CaseReportsPerHealthRisk
    {
        public HealthRiskName HealthRiskName { get; set; }
        public IList<CaseReportForMap> CaseReports { get; set; }
    }
}