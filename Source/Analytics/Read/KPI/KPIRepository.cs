using Read.CaseReports;
using Read.DataCollectors;
using Read.HealthRisks;
using Read.Models.KPI;
using System;
using System.Linq;

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
            PopulateCaseReportKPIs(kpi, from, to);
            PopulateDataCollectorKPIs(kpi, from, to);

            return kpi;

        }

        private void PopulateCaseReportKPIs(KPIs kpi, DateTimeOffset from, DateTimeOffset to)
        {
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
        }

        private void PopulateDataCollectorKPIs(KPIs kpi, DateTimeOffset from, DateTimeOffset to)
        {
            kpi.DataCollectors.TotalNumberOfDataCollectors = _mongoDBHandler.GetQueryable<DataCollector>().Count();

            kpi.DataCollectors.ActiveDataCollectors = _mongoDBHandler.GetQueryable<CaseReport>()
                .Where(x => x.Timestamp >= from && x.Timestamp < to)
                .Select(x => x.DataCollectorId)
                .Distinct()
                .Count();
        }
    }
}
