using Concepts;
using Concepts.HealthRisks;
using Dolittle.ReadModels;
using System;

namespace Read.HealthRisks
{
    public class HealthRisk : IReadModel
    {
        public HealthRiskId Id { get; set; }
        public HealthRiskName Name { get; set; }
    }
}
