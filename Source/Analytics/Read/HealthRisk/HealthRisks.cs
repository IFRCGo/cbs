using System.Collections.Generic;
using Dolittle.ReadModels;
using Concepts.HealthRisk;

namespace Read.HealthRisk
{
    public class HealthRisks : IReadModel
    {
        public ListId Id { get; set; }
        public IList<Concepts.HealthRisk.HealthRisk> AllHealthRisks { get; set; }
    }
}
