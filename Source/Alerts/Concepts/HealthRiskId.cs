using System;
using Dolittle.Concepts;
using Dolittle.Runtime.Events;

namespace Concepts
{
    public class HealthRiskId : ConceptAs<int>
    {
        public static implicit operator HealthRiskId(int id) => new HealthRiskId { Value = id };
    }
}