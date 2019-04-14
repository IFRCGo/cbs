using Read.HealthRisks;
using Read.Models.CaseReports;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Read.CaseReports
{
    public class CaseReportRepository
    {
        private readonly MongoDBHandler _mongoDBHandler;
        public CaseReportRepository(MongoDBHandler mongoDBHandler)
        {
            _mongoDBHandler = mongoDBHandler;
        }

        public CaseReportTotals GetCaseReportTotals(DateTimeOffset from, DateTimeOffset to)
        {
            var caseReportTotals = new CaseReportTotals();
            var queryable = _mongoDBHandler.GetQueryable<CaseReport>()
                .Where(x => x.Timestamp >= from && x.Timestamp < to);

            caseReportTotals.Female = queryable.Sum(x => x.NumberOfFemalesAged5AndOlder) + 
                queryable.Sum(x => x.NumberOfFemalesUnder5);
            caseReportTotals.Male = queryable.Sum(x => x.NumberOfMalesAged5AndOlder) +
                queryable.Sum(x => x.NumberOfMalesUnder5);
            caseReportTotals.Over5 = queryable.Sum(x => x.NumberOfFemalesAged5AndOlder) +
                queryable.Sum(x => x.NumberOfMalesAged5AndOlder);
            caseReportTotals.Under5 = queryable.Sum(x => x.NumberOfFemalesUnder5) +
                queryable.Sum(x => x.NumberOfMalesUnder5);

            return caseReportTotals;
        }

        public List<CaseReportTotalsPerHealthRisk> GetCaseReportTotalsPerHealthRisk(int numberOfWeeks)
        {
            var today = DateTimeOffset.Now;
            var days = numberOfWeeks * 7;
            var healthRisks = _mongoDBHandler.GetQueryable<HealthRisk>().ToList();
            var totalsList = new List<CaseReportTotalsPerHealthRisk>();

            foreach (var healthRisk in healthRisks)
            {
                var total = new CaseReportTotalsPerHealthRisk(healthRisk.Name);

                for (int i = 0; i < numberOfWeeks; i++){
                    var endDate = today.AddDays(i*-7);
                    var startDate = endDate.AddDays(-6);
                    var numberOfReportsThisWeek = healthRisk.ReportsPerDay.Where(x => x.Key >= startDate && x.Key <= endDate).Sum(x => x.Value);

                    total.ReportsPerWeek.Add(new ReportsPerWeek { Week = i, NumberOfReports = numberOfReportsThisWeek });
                }
                totalsList.Add(total);
            }
            return totalsList;
        }
    }
}
