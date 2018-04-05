using Dolittle.Concepts;
using System;
using System.Collections.Generic;
using System.Text;

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
