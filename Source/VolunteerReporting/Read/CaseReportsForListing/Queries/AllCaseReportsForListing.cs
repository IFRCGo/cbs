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

        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public IQueryable<CaseReportForListing> Query
        {
            get
            {
                if (PageSize > 0 && PageNumber > 0)
                {
                    return _collection.Query.Skip(PageSize * (PageNumber - 1)).Take(PageSize);
                }
                return _collection.Query;
            }
        }

    }
}
