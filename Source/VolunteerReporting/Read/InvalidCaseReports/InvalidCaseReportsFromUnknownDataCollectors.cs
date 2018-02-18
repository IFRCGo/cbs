using MongoDB.Driver;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<InvalidCaseReportFromUnknownDataCollector>> GetByPhoneNumber(string phoneNumber)
        {
            var filter = Builders<InvalidCaseReportFromUnknownDataCollector>.Filter.Eq(c => c.PhoneNumber, phoneNumber);
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public async Task Save(InvalidCaseReportFromUnknownDataCollector caseReport)
        {
            var filter = Builders<InvalidCaseReportFromUnknownDataCollector>.Filter.Eq(c => c.Id, caseReport.Id);
            await _collection.ReplaceOneAsync(filter, caseReport, new UpdateOptions { IsUpsert = true });
        }

        public async Task Remove(Guid id)
        {
            var filter = Builders<InvalidCaseReportFromUnknownDataCollector>.Filter.Eq(c => c.Id, id);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
