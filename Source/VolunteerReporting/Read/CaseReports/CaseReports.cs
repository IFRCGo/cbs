using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;

namespace Read.CaseReports
{
    public class CaseReports : ExtendedReadModelRepositoryFor<CaseReport>,
        ICaseReports
    {
        public const string CollectionName = "CaseReport";
        
        public CaseReports(IMongoDatabase database)
            : base(database)
        {
        }

        public IEnumerable<CaseReport> GetAll()
        {
            return GetMany(_ => true);
        }
    }
}
