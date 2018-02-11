using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.CaseReports
{
    public class CaseReports : ICaseReports
    {
        public const string CollectionName = "CaseReport";

        private IMongoDatabase _database;
        private IMongoCollection<CaseReport> _collection;

        public CaseReports(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<CaseReport>(CollectionName);
        }

        public async Task<IEnumerable<CaseReport>> GetAllAsync()
        {
            var filter = Builders<CaseReport>.Filter.Empty;
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public async Task Save(CaseReport caseReport)
        {
            var filter = Builders<CaseReport>.Filter.Eq(c => c.Id, caseReport.Id);
            await _collection.ReplaceOneAsync(filter, caseReport, new UpdateOptions { IsUpsert = true });
        }
    }
}
