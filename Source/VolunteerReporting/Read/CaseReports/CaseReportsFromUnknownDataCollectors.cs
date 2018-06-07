using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;

namespace Read.CaseReports
{
    public class CaseReportsFromUnknownDataCollectors : ExtendedReadModelRepositoryFor<CaseReportFromUnknownDataCollector>,
        ICaseReportsFromUnknownDataCollectors
    {
        public const string CollectionName = "CaseReportFromUnknownDataCollector";

        public CaseReportsFromUnknownDataCollectors(IMongoDatabase database)
            : base(database, database.GetCollection<CaseReportFromUnknownDataCollector>("CaseReportFromUnknownDataCollector"))
        {
        }

        public IEnumerable<CaseReportFromUnknownDataCollector> GetAll()
        {
            return GetMany(_ => true);
        }

        public Task<IEnumerable<CaseReportFromUnknownDataCollector>> GetAllAsync()
        {
            return GetManyAsync(_ => true);
        }

        public IEnumerable<CaseReportFromUnknownDataCollector> GetByPhoneNumber(string phoneNumber)
        {
            return GetMany(r => r.Origin == phoneNumber);
        }

        public Task<IEnumerable<CaseReportFromUnknownDataCollector>> GetByPhoneNumberAsync(string phoneNumber)
        {
            return GetManyAsync(r => r.Origin == phoneNumber);
        }
    }
}
