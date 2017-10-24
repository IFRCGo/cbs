using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.AnonymousCaseReports
{
    public class AnonymousCaseReports : IAnonymousCaseReports
    {
        public const string CollectionName = "AnonymousCaseReport";

        private IMongoDatabase _database;
        private IMongoCollection<AnonymousCaseReport> _collection;

        public AnonymousCaseReports(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<AnonymousCaseReport>(CollectionName);
        }

        public async Task<IEnumerable<AnonymousCaseReport>> GetAllAsync()
        {
            var filter = Builders<AnonymousCaseReport>.Filter.Empty;
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public void Save(AnonymousCaseReport anonymousCaseReport)
        {
            var filter = Builders<AnonymousCaseReport>.Filter.Eq(c => c.Id, anonymousCaseReport.Id);
            _collection.ReplaceOne(filter, anonymousCaseReport, new UpdateOptions { IsUpsert = true });
        }
    }
}
