using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.CaseReports
{
    public class AllCaseReportsQuery : IQueryFor<CaseReport>
    {
        readonly IReadModelRepositoryFor<CaseReport> _repositoryForCaseReport;

        public AllCaseReportsQuery(IReadModelRepositoryFor<CaseReport> repositoryForCaseReport)
        {
            _repositoryForCaseReport = repositoryForCaseReport;
        }

        public IQueryable Query => _repositoryForCaseReport.Query;
    }
}
