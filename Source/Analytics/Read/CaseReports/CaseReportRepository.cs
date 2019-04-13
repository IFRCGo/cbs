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

            caseReportTotals.Female = 
                queryable.Where(x => x.NumberOfFemalesAged5AndOlder > 0 || x.NumberOfFemalesUnder5 > 0).Count();
            caseReportTotals.Male =
              queryable.Where(x => x.NumberOfMalesAged5AndOlder > 0 || x.NumberOfMalesUnder5 > 0).Count();
            caseReportTotals.Over5 =
             queryable.Where(x => x.NumberOfFemalesAged5AndOlder > 0 || x.NumberOfMalesAged5AndOlder > 0).Count();
            caseReportTotals.Under5 =
           queryable.Where(x => x.NumberOfFemalesUnder5 > 0 || x.NumberOfMalesUnder5 > 0).Count();

            return caseReportTotals;
        }
    }
}
