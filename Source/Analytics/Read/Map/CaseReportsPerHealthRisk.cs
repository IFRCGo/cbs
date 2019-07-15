using System.Collections.Generic;
using Concepts.HealthRisk;

namespace Read.Map
{
    public class CaseReportsPerHealthRisk
    {
        public HealthRiskName HealthRiskName { get; set; }
        public IList<CaseReportForMap> CaseReports { get; set; }
    }
}