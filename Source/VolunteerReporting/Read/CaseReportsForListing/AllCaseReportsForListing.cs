/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.CaseReportsForListing
{
    public class AllCaseReportsForListing : IQueryFor<CaseReportForListing>
    {
        private readonly IReadModelRepositoryFor<CaseReportForListing> _collection;
        public AllCaseReportsForListing(IReadModelRepositoryFor<CaseReportForListing> collection)
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
                // TODO implementd sortfield
                var sortField = string.IsNullOrEmpty(SortField) ? nameof(CaseReportForListing.Timestamp) : SortField;
                var query = _collection.Query.OrderBy(x=>x.Timestamp);//.OrderBy(SortAscending);

                if (PageSize > 0 && PageNumber >= 0)
                {
                    return query.Skip(PageSize * PageNumber).Take(PageSize);
                }
                return query;
            }
        }
    }
}
