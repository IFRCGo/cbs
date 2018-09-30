using System;
using System.Linq;
using System.Linq.Expressions;
using Dolittle.Queries;
using Infrastructure.Read.Migration;

namespace Read.CaseReportsForListing
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
        public bool SortAscending { get; set; } 
        public string SortField { get; set; }

        public IQueryable<CaseReportForListing> Query
        {
            get
            {
                var sortField = string.IsNullOrEmpty(SortField) ? nameof(CaseReportForListing.Timestamp) : SortField;
                var query = _collection.Query.OrderByField(sortField, SortAscending);

                if (PageSize > 0 && PageNumber >= 0)
                {
                    return query.Skip(PageSize * PageNumber).Take(PageSize);
                }
                return query;
            }
        }
    }
}
