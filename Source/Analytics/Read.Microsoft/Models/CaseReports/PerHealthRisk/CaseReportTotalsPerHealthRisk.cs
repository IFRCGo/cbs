using System.Collections.Generic;

namespace Read.Models.CaseReports.PerHealthRisk
{
    public class CaseReportTotalsPerHealthRisk
    {
        public string Name { get; }

        public List<ReportsPerWeek> ReportsPerWeek { get; set;}

        public CaseReportTotalsPerHealthRisk(string name)
        {
            Name = name;
            ReportsPerWeek = new List<ReportsPerWeek>();
        }
    }
}
