using System.Collections.Generic;
using Concepts.HealthRisks;

namespace Read.Map
{
    public class CaseReportsRetrieved
    {
        public HealthRiskName HealthRiskName { get; set; }
        public IList<CaseReportForMap> CaseReportsLast7Days { get; set; }
        public IList<CaseReportForMap> CaseReportsLast30Days { get; set; }
    }
}