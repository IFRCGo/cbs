using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Map
{
    public class CaseReportsLast30DaysQuery : IQueryFor<CaseReportsLast30Days>
    {
        readonly IReadModelRepositoryFor<CaseReportsLast30Days> _repositoryForCaseReportsLast30Days;

        public CaseReportsLast30DaysQuery(IReadModelRepositoryFor<CaseReportsLast30Days> repositoryForCaseReportsLast30Days)
        {
            _repositoryForCaseReportsLast30Days = repositoryForCaseReportsLast30Days;
        }

        public IQueryable<CaseReportsLast30Days> Query => _repositoryForCaseReportsLast30Days.Query;
    }
}
