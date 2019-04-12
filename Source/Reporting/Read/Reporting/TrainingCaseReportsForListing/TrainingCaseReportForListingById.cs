/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Concepts.CaseReports;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Reporting.TrainingCaseReportsForListing
{
    public class TrainingCaseReportForListingById : IQueryFor<TrainingCaseReportForListing>
    {
        readonly IReadModelRepositoryFor<TrainingCaseReportForListing> _collection;
        public CaseReportId CaseReportId { get; set; }

        public TrainingCaseReportForListingById(IReadModelRepositoryFor<TrainingCaseReportForListing> collection)
        {
            _collection = collection;
        }

        public IQueryable<TrainingCaseReportForListing> Query => _collection.Query.Where(c => c.Id == CaseReportId);
    }
}