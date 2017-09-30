using System;
using MongoDB.Driver;

namespace Read
{
    public class CaseReports : Repository<CaseReport>, ICaseReports
    {
        public CaseReports(IMongoCollection<CaseReport> collection) : base(collection)
        {
        }
    }
}
