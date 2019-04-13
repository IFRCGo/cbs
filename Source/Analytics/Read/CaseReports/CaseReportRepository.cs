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
    }
}
