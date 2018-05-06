using Events.External;
using Dolittle.Events.Processing;
using System.Threading.Tasks;
using System;
using MongoDB.Driver;

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

        public void Process(HealthRiskModified @event)
        {
            //TODO: This is a little naive I think, some other changes in this Bounded Context has to be made when this event is emited
            _healthRisks.Update(Builders<HealthRisk>.Filter.Where(d => d.Id == @event.Id),
                Builders<HealthRisk>.Update.Combine(
                    Builders<HealthRisk>.Update.Set(h => h.Name, @event.Name),
                    Builders<HealthRisk>.Update.Set(h => h.ReadableId, @event.ReadableId)
                )
            );
        }

        public void Process(HealthRiskDeleted @event)
        {
            _healthRisks.Remove(@event.HealthRiskId);
        }
    }
}
