using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.CaseReports
{
    public class CaseReportsFromUnknownDataCollectors : ICaseReportsFromUnknownDataCollectors
    {
        public const string CollectionName = "CaseReportFromUnknownDataCollector";

        private IMongoDatabase _database;
        private IMongoCollection<CaseReportFromUnknownDataCollector> _collection;

        public CaseReportsFromUnknownDataCollectors(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<CaseReportFromUnknownDataCollector>(CollectionName);
        }

        public async Task<IEnumerable<CaseReportFromUnknownDataCollector>> GetAllAsync()
        {
            var filter = Builders<CaseReportFromUnknownDataCollector>.Filter.Empty;
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public async Task<IEnumerable<CaseReportFromUnknownDataCollector>> GetByPhoneNumber(string phoneNumber)
        {
            var filter = Builders<CaseReportFromUnknownDataCollector>.Filter.Eq(c => c.Origin, phoneNumber);
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public async Task Save(CaseReportFromUnknownDataCollector anonymousCaseReport)
        {
            var filter = Builders<CaseReportFromUnknownDataCollector>.Filter.Eq(c => c.Id, anonymousCaseReport.Id);
            await _collection.ReplaceOneAsync(filter, anonymousCaseReport, new UpdateOptions { IsUpsert = true });
        }

        public async Task Remove(Guid id)
        {
            var filter = Builders<CaseReportFromUnknownDataCollector>.Filter.Eq(c => c.Id, id);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
