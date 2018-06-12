using System;
using System.Linq;
using Concepts;
using Dolittle.Queries;

namespace Read.CaseReportsForListing.Queries
{
    public class CaseReportForListingById : IQueryFor<CaseReportForListing>
    {
        private readonly ICaseReportsForListing _collection;

        public CaseReportId CaseReportId { get; set; }

        public CaseReportForListingById(ICaseReportsForListing collection)
        {
            _collection = collection;
        }

        public IQueryable<CaseReportForListing> Query => _collection.Query.Where(c => c.Id == CaseReportId);
    }
}