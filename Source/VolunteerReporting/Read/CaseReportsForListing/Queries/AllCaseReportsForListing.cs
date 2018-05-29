
using System.Linq;
using Dolittle.Queries;

namespace Read.CaseReportsForListing.Queries
{
    public class AllCaseReportsForListing : IQueryFor<CaseReportForListing>
    {
        private readonly ICaseReportsForListing _collection;

        public AllCaseReportsForListing(ICaseReportsForListing collection)
        {
            _collection = collection;
        }

        public IQueryable<CaseReportForListing> Query => _collection.Query;
    }
}
