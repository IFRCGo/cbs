using Dolittle.ReadModels;

namespace Read
{
    public class HealthRisks : IReadModel
    {
        public ListId Id { get; set; }
        public IList<HealthRisk> AllHealthRisks { get; set; }
    }
}
