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
    public class GetCaseReportsPerRegionLast7Days : IQueryFor<CaseReportsPerRegionLast7Days>
    {
        readonly IReadModelRepositoryFor<CaseReportsPerRegionLast7Days> _repositoryForCaseReportsPerRegionLast7Days;

        public GetCaseReportsPerRegionLast7Days(IReadModelRepositoryFor<CaseReportsPerRegionLast7Days> repositoryForCaseReportsPerRegionLast7Days)
        {
            _repositoryForCaseReportsPerRegionLast7Days = repositoryForCaseReportsPerRegionLast7Days;
        }

        public IQueryable<CaseReportsPerRegionLast7Days> Query => 
            _repositoryForCaseReportsPerRegionLast7Days
                .Query
                .Where(report => report.Id == Day.Today); //Current testing data is static and not timestamped with today. To populate database for testing purposes, you can use a Day such as 17925.
    }
}
