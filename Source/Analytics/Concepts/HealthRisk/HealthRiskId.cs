using Dolittle.Concepts;
using System;

namespace Concepts.HealthRisk
{
    public class HealthRiskId : ConceptAs<Guid>
    {
        public static implicit operator HealthRiskId(Guid value)
        {
            return new HealthRiskId {Value = value};
        }

    }
}
