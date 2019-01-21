/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Concepts.CaseReports;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Reporting.CaseReportsForListing
{
    public class CaseReportForListingById : IQueryFor<CaseReportForListing>
    {
        readonly IReadModelRepositoryFor<CaseReportForListing> _collection;
        public CaseReportId CaseReportId { get; set; }

        public CaseReportForListingById(IReadModelRepositoryFor<CaseReportForListing> collection)
        {
            _collection = collection;
        }

        public IQueryable<CaseReportForListing> Query => _collection.Query.Where(c => c.Id == CaseReportId);
    }
}