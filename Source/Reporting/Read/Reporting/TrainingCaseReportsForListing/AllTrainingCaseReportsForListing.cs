/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;
using Read.Reporting.CaseReportsForListing;

namespace Read.Reporting.TrainingCaseReportsForListing
{
    public class TrainingAllCaseReportsForListing : IQueryFor<TrainingCaseReportForListing>
    {
        private readonly IReadModelRepositoryFor<TrainingCaseReportForListing> _collection;
        public TrainingAllCaseReportsForListing(IReadModelRepositoryFor<TrainingCaseReportForListing> collection)
        {
            _collection = collection;
        }

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public bool SortAscending { get; set; } 
        public string SortField { get; set; }

        public IQueryable<TrainingCaseReportForListing> Query
        {
            get
            {
                IQueryable<TrainingCaseReportForListing> query = _collection.Query;
                if (string.IsNullOrWhiteSpace(SortField))
                    query = SortAscending ? query.OrderBy(x => x.Timestamp) : query.OrderByDescending(x => x.Timestamp);
                else
                    query = query.OrderByFieldName(SortField, SortAscending);

                if (PageSize > 0 && PageNumber >= 0) query = query.Skip(PageSize * PageNumber).Take(PageSize);

                return query;
            }
        }
    }
}
