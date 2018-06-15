using System;
using Concepts;
using Concepts.HealthRisk;
using Dolittle.ReadModels;

namespace Read.HealthRisks
{
    public class HealthRisk : IReadModel
    {
        public HealthRiskId Id { get; set; }

        public HealthRiskReadableId ReadableId { get; set; }
        public string Name { get; set; }

        public HealthRisk(Guid id)
        {
            Id = id;
        }
    }
}
