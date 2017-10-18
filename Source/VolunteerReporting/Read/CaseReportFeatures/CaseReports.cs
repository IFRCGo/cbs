using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Read.CaseReportFeatures
{
    public class CaseReports : ICaseReports
    {
        private IMongoDatabase _database;
        private IMongoCollection<CaseReport> _collection;

        public CaseReports(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<CaseReport>("CaseReport");
        }

        public void Save(CaseReport caseReport)
        {
            var filter = Builders<CaseReport>.Filter.Eq(c => c.Id, caseReport.Id);
            _collection.ReplaceOne(filter, caseReport, new UpdateOptions { IsUpsert = true });
        }
    }
}
