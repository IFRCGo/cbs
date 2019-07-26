/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using System.Linq;
using Concepts;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.CaseReports
{
    public class CaseReportsPerHealthRiskPerDayQuery : IQueryFor<CaseReportsPerHealthRiskPerDay>
    {
        readonly IReadModelRepositoryFor<CaseReportsPerHealthRiskPerDay> _repositoryForCaseReportsPerHealthRiskPerDay;

        public int NumberOfDays { get; set; }

        public CaseReportsPerHealthRiskPerDayQuery(IReadModelRepositoryFor<CaseReportsPerHealthRiskPerDay> repositoryForCaseReportsPerHealthRiskPerDay)
        {
            _repositoryForCaseReportsPerHealthRiskPerDay = repositoryForCaseReportsPerHealthRiskPerDay;
        }

        public IQueryable<CaseReportsPerHealthRiskPerDay> Query => 
            _repositoryForCaseReportsPerHealthRiskPerDay
                .Query
                .Where(_ => _.Id > Day.Today - NumberOfDays);
    }
}
