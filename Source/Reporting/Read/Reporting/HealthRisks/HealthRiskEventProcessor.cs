/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Admin.Reporting.HealthRisks;

namespace Read.Reporting.HealthRisks
{
    public class HealthRiskEventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<HealthRisk> _healthRisks;

        public HealthRiskEventProcessor(IReadModelRepositoryFor<HealthRisk> healthRisks)
        {
            _healthRisks = healthRisks;
        }

        [EventProcessor("ee7504ec-9103-4d59-bda3-7c95dd0b617b")]
        public void Process(HealthRiskCreated @event)
        {
            var healthRisk = new HealthRisk(@event.Id)
            {
                ReadableId = @event.ReadableId,
                Name = @event.Name
            };

            _healthRisks.Insert(healthRisk);
        }

        [EventProcessor("a82b73a6-cf23-48ad-9047-fc720a9a8054")]
        public void Process(HealthRiskModified @event)
        {
            var healthRisk = _healthRisks.GetById(@event.Id);
            healthRisk.ReadableId = @event.ReadableId;
            healthRisk.Name = @event.Name;

            _healthRisks.Update(healthRisk);
        }

        [EventProcessor("2b66cf4d-ac12-4a08-957b-bed6dfae88de")]
        public void Process(HealthRiskDeleted @event)
        {
            var healthRisk = _healthRisks.GetById(@event.HealthRiskId);
            _healthRisks.Delete(healthRisk);
        }
    }
}