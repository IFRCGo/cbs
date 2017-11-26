using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.InvalidCaseReports
{
    public class InvalidCaseReports : IInvalidCaseReports
    {
        public const string CollectionName = "InvalidCaseReport";

        private IMongoDatabase _database;
        private IMongoCollection<InvalidCaseReport> _collection;

        public InvalidCaseReports(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<InvalidCaseReport>(CollectionName);
        }

        public async Task<IEnumerable<InvalidCaseReport>> GetAllAsync()
        {
            var filter = Builders<InvalidCaseReport>.Filter.Empty;
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public void Save(InvalidCaseReport caseReport)
        {
            var filter = Builders<InvalidCaseReport>.Filter.Eq(c => c.Id, caseReport.Id);
            _collection.ReplaceOne(filter, caseReport, new UpdateOptions { IsUpsert = true });
        }
    }
}
