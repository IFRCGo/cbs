using System;
using System.Linq;
using Dolittle.Queries;
using Infrastructure.Read.MongoDb;
using Read.CaseReportsForListing.Migration;

namespace Read.CaseReportsForListing.Queries
{
    public class CaseReportForListingById : IQueryFor<CaseReportForListing>
    {
        readonly ICaseReportsForListing _collection;
        readonly ICaseReportForListingMigrator _migrator;
        public Guid CaseReportId { get; set; }

        public CaseReportForListingById(ICaseReportsForListing collection, ICaseReportForListingMigrator migrator)
        {
            _collection = collection;
            _migrator = migrator;
        }

        public IQueryable<CaseReportForListing> Query => _collection.Query.Where(c => c.Id == CaseReportId).MigrateQuery(_migrator);
    }
}