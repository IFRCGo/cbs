using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;
using Concepts;

namespace Read.Overview.LastWeeksPerHealthRisk
{
    public class CaseReportsLastWeeksPerHealthRiskQuery : IQueryFor<CaseReportsLastWeeksPerHealthRisk>
    {
        readonly IReadModelRepositoryFor<CaseReportsLastWeeksPerHealthRisk> _repositoryForCaseReportsLastWeeksPerHealthRisk;

        public CaseReportsLastWeeksPerHealthRiskQuery(IReadModelRepositoryFor<CaseReportsLastWeeksPerHealthRisk> repositoryForCaseReportsLastWeeksPerHealthRisk)
        {
            _repositoryForCaseReportsLastWeeksPerHealthRisk = repositoryForCaseReportsLastWeeksPerHealthRisk;
        }

        public IQueryable<CaseReportsLastWeeksPerHealthRisk> Query => 
            _repositoryForCaseReportsLastWeeksPerHealthRisk
                .Query
                .Where(report => report.Id == Day.Today);
    }
}
