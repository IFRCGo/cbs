
using System.Linq;
using Dolittle.Queries;
using Infrastructure.Read.MongoDb;
using Read.CaseReportsForListing.Migration;

namespace Read.CaseReportsForListing.Queries
{
    public class AllCaseReportsForListing : IQueryFor<CaseReportForListing>
    {
        readonly ICaseReportsForListing _collection;
        public AllCaseReportsForListing(ICaseReportsForListing collection)
        {
            _collection = collection;
        }

        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public IQueryable<CaseReportForListing> Query
        {
            get
            {
                if (PageSize > 0)
                {
                    return _collection.Query.Skip(PageSize * (PageNumber - 1)).Take(PageSize);
                }
                return _collection.Query;
            }
        }

    }
}
