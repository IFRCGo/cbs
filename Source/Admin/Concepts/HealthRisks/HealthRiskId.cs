using System;
using Dolittle.Runtime.Events;

namespace Concepts.HealthRisks
{
    public class HealthRiskId : EventSourceId
    {
        public static implicit operator HealthRiskId(Guid id) => new HealthRiskId { Value = id };
    }
}