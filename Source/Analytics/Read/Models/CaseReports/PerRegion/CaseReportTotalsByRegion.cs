using System;
using System.Collections.Generic;
using System.Linq;

namespace Read.Models.CaseReports.PerRegion
{
    public class CaseReportTotalsByRegion
    {
        public DateTimeOffset From { get; }
        public DateTimeOffset To { get; }

        public List<HealthRisk> HealthRisks { get; set; }

        public CaseReportTotalsByRegion(DateTimeOffset from, DateTimeOffset to)
        {
            From = from;
            To = to;
            HealthRisks = new List<HealthRisk>();
        }

        public HealthRisk GetHealthRisk(string name)
        {
            return HealthRisks.FirstOrDefault(x => x.Name == name);
        }

        public void AddHealthRiskRegion(string healthRiskName, string regionName, int count)
        {
            var healthRisk = HealthRisks.FirstOrDefault(x => x.Name == healthRiskName);

            var region = healthRisk.Regions.FirstOrDefault(x => x.Name == regionName);

            if (region == null)
                healthRisk.Regions.Add(new Region { Name = regionName, NumberOfCaseReports = count });
            else
                region.NumberOfCaseReports += count;
        }
    }
}
