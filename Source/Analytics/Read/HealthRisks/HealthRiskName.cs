using Concepts.HealthRisks;
using Dolittle.ReadModels;
using HealthRiskNameConcept = Concepts.HealthRisks.HealthRiskName;

namespace Read.HealthRisks
{
    public class HealthRiskName : IReadModel
    {
        public HealthRiskId Id { get; set; }
        public HealthRiskNameConcept Name { get; set; }
    }
}
