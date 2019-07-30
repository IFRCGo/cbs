using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;
using Concepts;

namespace Read.CaseReports
{
    public class CaseReportsPerRegionLast7DaysQuery : IQueryFor<CaseReportsPerRegionLast4Weeks>
    {
        readonly IReadModelRepositoryFor<CaseReportsPerRegionLast4Weeks> _repositoryForCaseReportsPerRegionLast7Days;

        public CaseReportsPerRegionLast7DaysQuery(IReadModelRepositoryFor<CaseReportsPerRegionLast4Weeks> repositoryForCaseReportsPerRegionLast7Days)
        {
            _repositoryForCaseReportsPerRegionLast7Days = repositoryForCaseReportsPerRegionLast7Days;
        }

        public IQueryable<CaseReportsPerRegionLast4Weeks> Query => 
            _repositoryForCaseReportsPerRegionLast7Days
                .Query
                .Where(report => report.Id == Day.Today);
    }
}
