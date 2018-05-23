using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
