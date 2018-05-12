/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Events.Processing;
using Events.HealthRisk;
using MongoDB.Driver;

namespace Read.HealthRiskFeatures
{
    public class HealthRiskCreatedProcessor : ICanProcessEvents
    {
        private readonly IHealthRisks _healthRisks;

        public HealthRiskCreatedProcessor(IHealthRisks healthRisks)
        {
            _healthRisks = healthRisks;
        }

        public void Process(HealthRiskCreated @event)
        {
            var healthRisk = new HealthRisk
            {
                Id = @event.Id,
                Name = @event.Name,
                ReadableId = @event.ReadableId,
                CaseDefinition = @event.CaseDefinition,
                //ConfirmedCase = @event.ConfirmedCase,
                Note = @event.Note,
                //ProbableCase = @event.ProbableCase,
                CommunityCase = @event.CommunityCase,
                //SuspectedCase = @event.SuspectedCase,
                KeyMessage = @event.KeyMessage
            };
            _healthRisks.Save(healthRisk);
        }

        public void Process(ThresholdAddedToHealthRIsk @event)
        {
            _healthRisks.Update(_ => _.Id == @event.HealthRiskId,
                Builders<HealthRisk>.Update.Set(_ => _.Threshold, @event.Threshold));
        }

        public void Process(HealthRiskModified @event)
        {
            //TODO: Use Update instead
            var healthRisk = new HealthRisk
            {
                Id = @event.Id,
                Name = @event.Name,
                ReadableId = @event.ReadableId,
                CaseDefinition = @event.CaseDefinition,
                //ConfirmedCase = @event.ConfirmedCase,
                Note = @event.Note,
                //ProbableCase = @event.ProbableCase,
                CommunityCase = @event.CommunityCase,
                //SuspectedCase = @event.SuspectedCase,
                KeyMessage = @event.KeyMessage
            };
            _healthRisks.Save(healthRisk);
        }

        public void Process(HealthRiskDeleted @event)
        {
            _healthRisks.Delete(@event.HealthRiskId);
        }
    }
}