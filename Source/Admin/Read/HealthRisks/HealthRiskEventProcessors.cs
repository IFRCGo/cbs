/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.HealthRisks;
using Infrastructure.Read.MongoDb;
using MongoDB.Driver;

namespace Read.HealthRisks
{
    public class HealthRiskEventProcessors : ICanProcessEvents
    {
        private readonly IExtendedReadModelRepositoryFor<HealthRisk> _repository;

        public HealthRiskEventProcessors(IExtendedReadModelRepositoryFor<HealthRisk> repository)
        {
            _repository = repository;
        }
        
        [EventProcessor("c13a6652-5bd2-428e-b446-7646c2a6e991")]
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
            _repository.Insert(healthRisk);
        }
        [EventProcessor("365fe247-dd3c-4f85-9d24-052f954c3cf8")]
        public void Process(ThresholdAddedToHealthRIsk @event)
        {
        //TODO: Have this again when dolittle build tool supports nullables 
            // _healthRisks.Update(_ => _.Id == @event.HealthRiskId,
            //     Builders<HealthRisk>.Update.Set(_ => _.Threshold, /*@event.Threshold));
        }
        [EventProcessor("ef9fe8d4-eb58-4649-bc96-0e3e472a0689")]
        public void Process(HealthRiskModified @event)
        {
            _repository.Update(risk => risk.Id == @event.Id, Builders<HealthRisk>.Update.Combine(
                Builders<HealthRisk>.Update.Set(risk => risk.Name, @event.Name),
                Builders<HealthRisk>.Update.Set(risk => risk.ReadableId, @event.ReadableId),
                Builders<HealthRisk>.Update.Set(risk => risk.CaseDefinition, @event.CaseDefinition),
                Builders<HealthRisk>.Update.Set(risk => risk.Note, @event.Note),
                Builders<HealthRisk>.Update.Set(risk => risk.CommunityCase, @event.CommunityCase),
                Builders<HealthRisk>.Update.Set(risk => risk.KeyMessage, @event.KeyMessage)
                ));
        }
        [EventProcessor("11de10e1-fa78-447c-8ce9-34eb46ade455")]
        public void Process(HealthRiskDeleted @event)
        {
            _repository.Delete(risk => risk.Id == @event.HealthRiskId);
        }
    }
}