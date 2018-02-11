/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using doLittle.Events.Processing;
using Events;

namespace Read.HealthRiskFeatures
{
    public class HealthRiskCreatedProcessor : ICanProcessEvents
    {
        readonly IHealthRisks _healthRisks;

        public HealthRiskCreatedProcessor(IHealthRisks healthRisks)
        {
            _healthRisks = healthRisks;
        }

        public void Process(HealthRiskCreated @event)
        {
            var healthRisk = new HealthRisk()
            {
                Id = @event.Id,
                Name = @event.Name,
                ReadableId = @event.ReadableId,
                Threshold = @event.Threshold,
                ConfirmedCase = @event.ConfirmedCase,
                Note = @event.Note,
                ProbableCase = @event.ProbableCase,
                CommunityCase = @event.CommunityCase,
                SuspectedCase = @event.SuspectedCase,
                KeyMessage = @event.KeyMessage
            };
            _healthRisks.Save(healthRisk);
        }
    }
}