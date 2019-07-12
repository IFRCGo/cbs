using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;
using Concepts;

namespace Read.Map
{
    public class CaseReportsBeforeDayQuery : IQueryFor<CaseReportsBeforeDay>
    {
        readonly IReadModelRepositoryFor<CaseReportsBeforeDay> _repositoryForCaseReportsBeforeDay;

        public CaseReportsBeforeDayQuery(IReadModelRepositoryFor<CaseReportsBeforeDay> repositoryForCaseReportsBeforeDay)
        {
            _repositoryForCaseReportsBeforeDay = repositoryForCaseReportsBeforeDay;
        }
        public IQueryable<CaseReportsBeforeDay> Query => _repositoryForCaseReportsBeforeDay.Query.Where(caseReports => caseReports.Id == Day.Today);
    }
}
