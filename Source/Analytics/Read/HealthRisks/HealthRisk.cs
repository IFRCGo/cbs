using Dolittle.ReadModels;
using Concepts.HealthRisks;

namespace Read.HealthRisks
{
    public class HealthRisk : IReadModel
    {
        public HealthRiskId Id { get; set; }
        public HealthRiskName Name { get; set; }
        public HealthRiskNumber HealthRiskNumber { get; set; }
    }
}