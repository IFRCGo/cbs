using doLittle.Concepts;
using System;

namespace Concepts
{
    public class HealthRiskId : ConceptAs<Guid>
    {
        public static readonly HealthRiskId NotSet = Guid.Empty;

        public static implicit operator HealthRiskId(Guid id)
        {
            return new HealthRiskId { Value = id };
        }

    }
}
