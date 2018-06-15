
using System.Linq;
using Dolittle.Queries;
using Infrastructure.Read.MongoDb;
using Read.CaseReportsForListing.Migration;

namespace Read.CaseReportsForListing.Queries
{
    public class AllCaseReportsForListing : IQueryFor<CaseReportForListing>
    {
        readonly ICaseReportsForListing _collection;
        readonly ICaseReportForListingMigrator _migrator;
        public AllCaseReportsForListing(ICaseReportsForListing collection, ICaseReportForListingMigrator migrator)
        {
            _collection = collection;
            _migrator = migrator;
        }

        public IQueryable<CaseReportForListing> Query => _collection.Query;
    }
}
