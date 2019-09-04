/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Admin.HealthRisks;

namespace Read.HealthRisks
{
    public class EventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<HealthRisk> _healthRisks;

        public EventProcessor(IReadModelRepositoryFor<HealthRisk> healthRisks)
        {
            _healthRisks = healthRisks;
        }

        [EventProcessor("9c62046d-eb9a-ab1d-8d56-af179f20cfc2")]
        public void Process(HealthRiskCreated @event)
        {
            _healthRisks.Insert(new HealthRisk
            {
                Id = @event.Id,
                Name = @event.Name,
                HealthRiskNumber = @event.HealthRiskNumber
            });
        }

        [EventProcessor("d2a2762d-aa9e-48dd-6667-629e2d64f16a")]
        public void Process(HealthRiskModified @event)
        {
            var healthRisk = _healthRisks.GetById(@event.Id);
            healthRisk.Name = @event.Name;
            _healthRisks.Update(healthRisk);
        }

        [EventProcessor("9978d974-582f-4692-b106-a85b8488158a")]
        public void Process(HealthRiskDeleted @event)
        {
            var healthRisk = _healthRisks.GetById(@event.HealthRiskId);
            _healthRisks.Delete(healthRisk);
        }
    }
}
