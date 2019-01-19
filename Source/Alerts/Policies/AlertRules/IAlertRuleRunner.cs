using Dolittle.ReadModels;
using Read.CaseReports;

namespace Policies.AlertRules
{
    public interface IAlertRuleRunner
    {
        AlertRuleRunResult RunAlertRule(IReadModelRepositoryFor<Case> casesAllQuery);
    }
}
