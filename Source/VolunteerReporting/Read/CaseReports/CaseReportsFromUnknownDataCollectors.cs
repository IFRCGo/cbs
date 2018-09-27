using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;

namespace Read.CaseReports
{
    public class CaseReportsFromUnknownDataCollectors : ExtendedReadModelRepositoryFor<CaseReportFromUnknownDataCollector>,
        ICaseReportsFromUnknownDataCollectors
    {
        public CaseReportsFromUnknownDataCollectors(IMongoDatabase database)
            : base(database)
        {
        }
        public IEnumerable<CaseReportFromUnknownDataCollector> GetAll()
        {
            return GetMany(_ => true);
        }

        public IEnumerable<CaseReportFromUnknownDataCollector> GetByPhoneNumber(string phoneNumber)
        {
            return GetMany(r => r.Origin == phoneNumber);
        }
    }
}
