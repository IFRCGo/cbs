using System.Collections.Generic;
using Concepts.HealthRisk;

namespace Read.Map
{
    public class CaseReportsRetrieved
    {
        public HealthRiskName HealthRiskName { get; set; }
        public IList<CaseReportForMap> CaseReportsLast7Days { get; set; }
        public IList<CaseReportForMap> CaseReportsLast30Days { get; set; }
    }
}