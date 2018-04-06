using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.CaseReportsForListing
{
    public class CaseReportsForListing : ICaseReportsForListing
    {
        public const string CollectionName = "CaseReportForListing";

        private IMongoDatabase _database;
        private IMongoCollection<CaseReportForListing> _collection;

        public CaseReportsForListing(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<CaseReportForListing>(CollectionName);
        }

        public async Task<IEnumerable<CaseReportForListing>> GetAllAsync()
        {
            var filter = Builders<CaseReportForListing>.Filter.Empty;
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public async Task<IEnumerable<CaseReportForListing>> GetLimitAsync(int limit, bool last)
        {
            
            var filter = Builders<CaseReportForListing>.Filter.Empty;

            // TODO: Can we assume that this explicit conversion is safe?
            var totalDocuments = (int)await _collection.CountAsync(filter);

            limit = (limit > totalDocuments) ? totalDocuments : limit;

            var options = new FindOptions<CaseReportForListing>()
            {
                Skip = last ? totalDocuments - limit : 0,
                Limit = limit
            };   
            var list = await _collection.FindAsync(filter, options);

            return await list.ToListAsync();
        }

        public async Task Save(CaseReportForListing caseReport)
        {
            var filter = Builders<CaseReportForListing>.Filter.Eq(c => c.Id, caseReport.Id);
            await _collection.ReplaceOneAsync(filter, caseReport, new UpdateOptions { IsUpsert = true });
        }

        public async Task Remove(Guid id)
        {
            var filter = Builders<CaseReportForListing>.Filter.Eq(c => c.Id, id);
            await _collection.DeleteOneAsync(filter);
        }

    }
}
