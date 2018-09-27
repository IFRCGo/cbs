
using System.Linq;
using Dolittle.Queries;
using Infrastructure.Read.MongoDb;
using Read.CaseReportsForListing.Migration;

namespace Read.CaseReportsForListing
{
    public class AllCaseReportsForListing : IQueryFor<CaseReportForListing>
    {
        readonly ICaseReportsForListing _collection;
        public AllCaseReportsForListing(ICaseReportsForListing collection)
        {
            _collection = collection;
        }

        public IQueryable<CaseReportForListing> Query => _collection.Query;
    }
}
