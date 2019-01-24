using System;
using System.Collections.Generic;

namespace Policies.AlertRules
{
    public class AlertRuleRunResult
    {
        public AlertRuleRunResult(
            IReadOnlyList<Guid> cases, 
            Guid alertRuleId)
        {
            Triggered = cases.Count > 0;
            Cases = cases;
            AlertRuleId = alertRuleId;
        }

        public static AlertRuleRunResult NotTriggeredResult { get; } 
            = new AlertRuleRunResult(new List<Guid>(0), Guid.Empty);

        public bool Triggered { get; }
        public IReadOnlyList<Guid> Cases { get; }
        public Guid AlertRuleId { get; }
    }
}
