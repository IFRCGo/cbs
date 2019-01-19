using Read;
using Read.CaseReports;

namespace Policies.AlertRules
{
    public interface IAlertRuleRunner
    {
        AlertRuleRunResult RunAlertRule(IAllQuery<Case> casesAllQuery);
    }
}
