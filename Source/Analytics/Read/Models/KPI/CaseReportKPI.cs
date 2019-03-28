namespace Read.Models.KPI
{
    public class CaseReportKPI
    {
        public int TotalNumberOfReports { get; set; }
        public ReportedHealthRisk[] ReportedHealthRisks { get; set; }
    }
}
