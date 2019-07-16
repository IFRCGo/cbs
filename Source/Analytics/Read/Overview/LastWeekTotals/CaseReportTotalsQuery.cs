using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;
using Concepts;

namespace Read.Overview.LastWeekTotals
{
    public class CaseReportTotalsQuery : IQueryFor<CaseReportTotals>
    {
        readonly IReadModelRepositoryFor<CaseReportTotals> _repositoryForCaseReportTotals;

        public CaseReportTotalsQuery(IReadModelRepositoryFor<CaseReportTotals> repositoryForCaseReportTotals)
        {
            _repositoryForCaseReportTotals = repositoryForCaseReportTotals;
        }

        public IQueryable<CaseReportTotals> Query => 
            _repositoryForCaseReportTotals
            .Query
            .Where(report => report.Id == Day.Today);
    }
}
