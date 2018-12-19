/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Concepts.CaseReport;
using Dolittle.Queries;

namespace Read.CaseReportsForListing
{
    public class CaseReportForListingById : IQueryFor<CaseReportForListing>
    {
        readonly ICaseReportsForListing _collection;
        public CaseReportId CaseReportId { get; set; }

        public CaseReportForListingById(ICaseReportsForListing collection)
        {
            _collection = collection;
        }

        public IQueryable<CaseReportForListing> Query => _collection.Query.Where(c => c.Id == CaseReportId);
    }
}