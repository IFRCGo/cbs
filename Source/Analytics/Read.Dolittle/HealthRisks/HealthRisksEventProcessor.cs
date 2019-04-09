using Dolittle.Events.Processing;
using Events.Admin.HealthRisks;
using Read.HealthRisks;

namespace Read.Dolittle.HealthRisks
{
    public class HealthRisksEventProcessor : ICanProcessEvents
    {
        private readonly IHealthRisksEventHandler _healthRisksEventHandler;

        public HealthRisksEventProcessor(IHealthRisksEventHandler healthRisksEventHandler)
        {
            _healthRisksEventHandler = healthRisksEventHandler;
        }

        [EventProcessor("cb01aaaf-7998-4692-81ef-1ceb5ab38e13")]
        public void Process(HealthRiskCreated @event)
        {
            var healthRisk = new HealthRisk(@event.Id, @event.Name);

            _healthRisksEventHandler.Handle(healthRisk);
        }
    }
}
