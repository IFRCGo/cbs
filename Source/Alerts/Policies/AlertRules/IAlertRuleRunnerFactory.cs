using System.Collections.Generic;

namespace Policies.AlertRules
{
    public interface IAlertRuleRunnerFactory
    {
        IEnumerable<IAlertRuleRunner> GetRelevantAlertRules(int healthRiskNumber);
    }
}
