using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Overview.Last4WeeksPerHealthRisk
{
    public class CaseReportsLast4WeeksPerHealthRiskQuery : IQueryFor<CaseReportsLast4WeeksPerHealthRisk>
    {
        readonly IReadModelRepositoryFor<CaseReportsLast4WeeksPerHealthRisk> _repositoryForCaseReportsLastWeeksPerHealthRisk;

        public CaseReportsLast4WeeksPerHealthRiskQuery(IReadModelRepositoryFor<CaseReportsLast4WeeksPerHealthRisk> repositoryForCaseReportsLastWeeksPerHealthRisk)
        {
            _repositoryForCaseReportsLastWeeksPerHealthRisk = repositoryForCaseReportsLastWeeksPerHealthRisk;
        }

        public IQueryable<CaseReportsLast4WeeksPerHealthRisk> Query => _repositoryForCaseReportsLastWeeksPerHealthRisk.Query;
    }
}
