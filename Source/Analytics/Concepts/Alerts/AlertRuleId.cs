using Dolittle.Concepts;
using System;

namespace Concepts.Alerts
{
    public class AlertRuleId : ConceptAs<Guid>
    {
        public static implicit operator AlertRuleId(Guid value)
        {
            return new AlertRuleId {Value = value};
        }
    }
}
