using System.Collections.Generic;
using System.Linq;

namespace Read.Models.KPI
{
    public class KPIs
    {
        public CaseReportKPI CaseReports { get; }
        public DataCollectorKPI DataCollectors { get; }

        public KPIs()
        {
            CaseReports = new CaseReportKPI();
            DataCollectors = new DataCollectorKPI();
        }

        public List<ReportedHealthRisk> GetRecordedHealthRisks()
        {
            return CaseReports.ReportedHealthRisks;
        }

        public void SetRecordedHealthRisks(List<ReportedHealthRisk> reportedHealthRisks)
        {
            CaseReports.ReportedHealthRisks = reportedHealthRisks;
        }
    }
}
