/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.CaseReports
{
    public class TotalReportsQuery : IQueryFor<TotalReports>
    {
        readonly IReadModelRepositoryFor<TotalReports> _repositoryForTotalReports;

        public TotalReportsQuery(IReadModelRepositoryFor<TotalReports> repositoryForTotalReports)
        {
            _repositoryForTotalReports = repositoryForTotalReports;
        }

        public IQueryable<TotalReports> Query => _repositoryForTotalReports.Query;
    }
}
