using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Read
{
    public class CaseReports : Repository<CaseReport>, ICaseReports
    {
        private readonly IMongoCollection<CaseReport> _collection;

        public CaseReports(IMongoCollection<CaseReport> collection) : base(collection)
        {
            _collection = collection;
        }

        public IEnumerable<CaseReport> GetCaseReportsAfterDate(DateTime date)
        {
            return _collection.FindSync(report => report.SubmissionTimestamp > date).ToEnumerable();
        }
    }
}
