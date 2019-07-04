using Dolittle.ReadModels;
using Concepts.HealthRisk;

namespace Read.HealthRisk
{
    public class HealthRisk : IReadModel
    {
        public HealthRiskId Id { get; set; }
        public HealthRiskName Name { get; set; }
        public HealthRiskNumber HealthRiskNumber { get; set; }
    }
}