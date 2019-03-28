using System.Collections.Generic;
using System.Linq;

namespace Read.Models.KPI
{
    public class KPIs
    {
        public CaseReportKPI CaseReports { get; }
        public DataCollectorKPI DataCollectors { get; }
        public AlertKPI Alerts { get; }

        public KPIs()
        {
            CaseReports = new CaseReportKPI();
            DataCollectors = new DataCollectorKPI();
            Alerts = new AlertKPI();
        }

        public List<ReportedHealthRisk> GetRecordedHealthRisks()
        {
            return CaseReports.ReportedHealthRisks.ToList();
        }

        public void SetRecordedHealthRisks(List<ReportedHealthRisk> reportedHealthRisks)
        {
            CaseReports.ReportedHealthRisks = reportedHealthRisks.ToArray();
        }
    }
}
