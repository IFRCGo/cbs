using System;
using System.Linq;
using Dolittle.Queries;

namespace Read.CaseReportsForListing.Queries
{
    public class CaseReportById : IQueryFor<CaseReportForListing>
    {
        private readonly ICaseReportsForListing _collection;

        public Guid CaseReportId { get; set; }

        public CaseReportById(ICaseReportsForListing collection)
        {
            _collection = collection;
        }

        public IQueryable<CaseReportForListing> Query => _collection.Query.Where(c => c.Id == CaseReportId);
    }
}