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
        public Guid CaseReportId { get; set; }

        public CaseReportForListingById(ICaseReportsForListing collection)
        {
            _collection = collection;
        }

        public IQueryable<CaseReportForListing> Query => _collection.Query.Where(c => c.Id == CaseReportId);
    }
}