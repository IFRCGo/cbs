using Dolittle.ReadModels;
using Read.Reports;

namespace Policies.AlertRules
{
    public interface IAlertRuleRunner
    {
        AlertRuleRunResult RunAlertRule(IReadModelRepositoryFor<Report> casesAllQuery);
    }
}
