using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.InvalidCaseReports
{
    public class InvalidCaseReportsFromUnknownDataCollectors : IInvalidCaseReportsFromUnknownDataCollectors
    {

        public const string CollectionName = "InvalidCaseReportFromUnknownDataCollector";

        private IMongoDatabase _database;
        private IMongoCollection<InvalidCaseReportFromUnknownDataCollector> _collection;

        public InvalidCaseReportsFromUnknownDataCollectors(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<InvalidCaseReportFromUnknownDataCollector>(CollectionName);
        }

        public async Task<IEnumerable<InvalidCaseReportFromUnknownDataCollector>> GetAllAsync()
        {
            var filter = Builders<InvalidCaseReportFromUnknownDataCollector>.Filter.Empty;
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public void Save(InvalidCaseReportFromUnknownDataCollector caseReport)
        {
            var filter = Builders<InvalidCaseReportFromUnknownDataCollector>.Filter.Eq(c => c.Id, caseReport.Id);
            _collection.ReplaceOne(filter, caseReport, new UpdateOptions { IsUpsert = true });
        }
    }
}
