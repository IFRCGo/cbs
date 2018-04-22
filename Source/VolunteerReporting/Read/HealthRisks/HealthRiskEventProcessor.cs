using Events.External;
using Dolittle.Events.Processing;
using System.Threading.Tasks;
using System;
namespace Read.HealthRisks
{
    public class HealthRiskEventProcessor : ICanProcessEvents
    {
        readonly IHealthRisks _healthRisks;

        public HealthRiskEventProcessor(IHealthRisks healthRisks)
        {
            _healthRisks = healthRisks;
        }

        public void Process(HealthRiskCreated @event)
        {
            var healthRisk = new HealthRisk(@event.Id)
            {
                ReadableId = @event.ReadableId,
                Name = @event.Name
            };
            _healthRisks.Save(healthRisk);
        }
    }
}
