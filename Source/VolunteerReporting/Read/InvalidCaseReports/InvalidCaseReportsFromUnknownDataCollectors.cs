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

        public IEnumerable<InvalidCaseReportFromUnknownDataCollector> GetAll()
        {
            return _collection.FindSync(_ => true).ToList();
        }

        public async Task<IEnumerable<InvalidCaseReportFromUnknownDataCollector>> GetAllAsync()
        {
            var filter = Builders<InvalidCaseReportFromUnknownDataCollector>.Filter.Empty;
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public IEnumerable<InvalidCaseReportFromUnknownDataCollector> GetByPhoneNumber(string phoneNumber)
        {
            return _collection.FindSync(_ => _.PhoneNumber == phoneNumber).ToList();
        }

        public async Task<IEnumerable<InvalidCaseReportFromUnknownDataCollector>> GetByPhoneNumberAsync(string phoneNumber)
        {
            var filter = Builders<InvalidCaseReportFromUnknownDataCollector>.Filter.Eq(c => c.PhoneNumber, phoneNumber);
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public void Remove(Guid id)
        {
            _collection.DeleteOne(_ => _.Id == id);
        }

        public void Save(InvalidCaseReportFromUnknownDataCollector caseReport)
        {
            _collection.ReplaceOne(_=> _.Id == caseReport.Id, caseReport, new UpdateOptions {IsUpsert = true});
        }

        public async Task SaveAsync(InvalidCaseReportFromUnknownDataCollector caseReport)
        {
            var filter = Builders<InvalidCaseReportFromUnknownDataCollector>.Filter.Eq(c => c.Id, caseReport.Id);
            await _collection.ReplaceOneAsync(filter, caseReport, new UpdateOptions { IsUpsert = true });
        }

        public async Task RemoveAsync(Guid id)
        {
            var filter = Builders<InvalidCaseReportFromUnknownDataCollector>.Filter.Eq(c => c.Id, id);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
