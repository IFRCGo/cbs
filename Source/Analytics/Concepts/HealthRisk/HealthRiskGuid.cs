using Dolittle.Concepts;
using System;

namespace Concepts
{
    public class HealthRiskGuid : ConceptAs<Guid>
    {
        public static implicit operator HealthRiskGuid(Guid value)
        {
            return new HealthRiskGuid {Value = value};
        }
    }
}
