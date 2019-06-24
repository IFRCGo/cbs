using Dolittle.Concepts;
using System;

namespace Concepts.HealthRisk
{
    public class HealthRiskId : ConceptAs<Guid>
    {
        public static HealthRiskId None = default(Guid);
        public static implicit operator HealthRiskId(Guid id) => new HealthRiskId { Value = id };
        public static implicit operator HealthRiskId(string id) => new HealthRiskId { Value = new Guid(id) };

    }
}
