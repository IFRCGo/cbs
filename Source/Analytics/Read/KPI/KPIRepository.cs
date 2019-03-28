using Read.HealthRisks;
using Read.Models.KPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Read.KPI
{
    public class KPIRepository
    {
        private readonly MongoDBHandler _mongoDBHandler;
        public KPIRepository(MongoDBHandler mongoDBHandler)
        {
            _mongoDBHandler = mongoDBHandler;
        }

        public KPIs Get(DateTimeOffset from, DateTimeOffset to)
        {
            var kpi = new KPIs();
            var reportedHealthRisks = kpi.GetRecordedHealthRisks();

            var healthRisks = _mongoDBHandler.GetQueryable<HealthRisk>()
                .Where(x => x.ReportsPerDay.Count != 0).ToList();

            int total = 0;
            foreach (var healthRisk in healthRisks)
            {
                int numReports = healthRisk.ReportsPerDay.Where(x => x.Key >= from && x.Key < to).Sum(x => x.Value);
                if (numReports == 0)
                    continue;

                total += numReports;
                var reportedHealthRisk = reportedHealthRisks.SingleOrDefault(x => x.Name == healthRisk.Name);
                if (reportedHealthRisk == null)
                    reportedHealthRisks.Add(new ReportedHealthRisk
                    {
                        Name = healthRisk.Name,
                        NumberOfReports = numReports
                    });
                else
                    reportedHealthRisk.AddNumberOfReports(numReports);
            }

            kpi.CaseReports.TotalNumberOfReports = total;
            kpi.SetRecordedHealthRisks(reportedHealthRisks);

            return kpi;

        }
    }
}
