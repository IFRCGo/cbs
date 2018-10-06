using System.Collections.Generic;
using System.Linq;
using Concepts.HealthRisks;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.HealthRisks;

namespace Read.HealthRisks
{
    public class KeyMessageEventProcessors : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<HealthRisk> _repository;

        public KeyMessageEventProcessors(IReadModelRepositoryFor<HealthRisk> repository)
        {
            _repository = repository;
        }

        public void Process(KeyMessageAddedToHealthRisk @event)
        {
            var healthRisk = _repository.GetById(@event.HealthRiskId);
            healthRisk.KeyMessages = new List<KeyMessage>(healthRisk.KeyMessages)
            {
                new KeyMessage 
                {
                    Id = @event.KeyMessageId,
                    Message = @event.Message,
                    Language = @event.Language
                }
            };
            _repository.Update(healthRisk);
        }

    }
}