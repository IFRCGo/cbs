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
                CaseDefinition = @event.CaseDefinition
            };
            _repository.Insert(healthRisk);
        }
        
        [EventProcessor("11de10e1-fa78-447c-8ce9-34eb46ade455")]
        public void Process(HealthRiskDeleted @event)
        {
            _repository.Delete(risk => risk.Id == @event.HealthRiskId);
        }
    }
}