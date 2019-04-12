using System.Collections.Generic;

namespace Read.Models.KPI
{
    public class CaseReportKPI
    {
        public int TotalNumberOfReports { get; set; }
        public List<ReportedHealthRisk> ReportedHealthRisks { get; set; }

        public CaseReportKPI()
        {
            ReportedHealthRisks = new List<ReportedHealthRisk>();
        }
    }
}
