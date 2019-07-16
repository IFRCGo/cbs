/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;
using Concepts;

namespace Read.CaseReports
{
    public class CaseReportsPerRegionLast7DaysQuery : IQueryFor<CaseReportsPerRegionLast7Days>
    {
        readonly IReadModelRepositoryFor<CaseReportsPerRegionLast7Days> _repositoryForCaseReportsPerRegionLast7Days;

        public CaseReportsPerRegionLast7DaysQuery(IReadModelRepositoryFor<CaseReportsPerRegionLast7Days> repositoryForCaseReportsPerRegionLast7Days)
        {
            _repositoryForCaseReportsPerRegionLast7Days = repositoryForCaseReportsPerRegionLast7Days;
        }

        public IQueryable<CaseReportsPerRegionLast7Days> Query => 
            _repositoryForCaseReportsPerRegionLast7Days
                .Query
                .Where(report => report.Id == Day.Today);
    }
}
