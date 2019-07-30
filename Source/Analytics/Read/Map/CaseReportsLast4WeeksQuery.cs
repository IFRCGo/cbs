using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Map
{
    public class CaseReportsLast4WeeksQuery : IQueryFor<CaseReportsLast4Weeks>
    {
        readonly IReadModelRepositoryFor<CaseReportsLast4Weeks> _repositoryForCaseReportsLast4Weeks;

        public CaseReportsLast4WeeksQuery(IReadModelRepositoryFor<CaseReportsLast4Weeks> repositoryForCaseReportsLast4Weeks)
        {
            _repositoryForCaseReportsLast4Weeks = repositoryForCaseReportsLast4Weeks;
        }

        public IQueryable<CaseReportsLast4Weeks> Query => _repositoryForCaseReportsLast4Weeks.Query;
    }
}
