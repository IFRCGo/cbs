using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.CaseReports
{
    public class AllCases : IQueryFor<Case>
    {
        readonly IReadModelRepositoryFor<Case> _repositoryForCase;

        public AllCases(IReadModelRepositoryFor<Case> repositoryForCase)
        {
            _repositoryForCase = repositoryForCase;
        }

        public IQueryable<Case> Query => _repositoryForCase.Query;
    }
}
