using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;
using Concepts;

namespace Read.Map
{
    public class CaseReportsLast7DaysQuery : IQueryFor<CaseReportsLast7Days>
    {
        readonly IReadModelRepositoryFor<CaseReportsLast7Days> _repositoryForCaseReportsBeforeDay;

        public CaseReportsLast7DaysQuery(IReadModelRepositoryFor<CaseReportsLast7Days> repositoryForCaseReportsBeforeDay)
        {
            _repositoryForCaseReportsBeforeDay = repositoryForCaseReportsBeforeDay;
        }
        public IQueryable<CaseReportsLast7Days> Query => _repositoryForCaseReportsBeforeDay.Query.Where(caseReports => caseReports.Id == Day.SomeDay);
    }
}
