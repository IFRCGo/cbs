using Concepts;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.CaseReports;

namespace Read.CaseReports
{
    public class CaseEventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<Case> _repositoryForCase;

        public CaseEventProcessor(
            IReadModelRepositoryFor<Case> repositoryForCase            
        )
        {
            _repositoryForCase = repositoryForCase;
        }
        
        [EventProcessor("9eb306f7-e761-a0da-f000-34d915b8ff44")]
        public void Process(CaseRegistered @event)
        {
            var caseItem = new Case(@event.CaseId)
            {
                CaseReportId = @event.CaseReportId,
                DataCollectorId = @event.DataCollectorId,
                AgeGroup = (AgeGroup)@event.AgeGroup,
                Sex = (Sex)@event.Sex,
                HealthRiskId = @event.HealthRiskId,
                HealthRiskNumber = @event.HealthRiskNumber,
                Latitude = @event.Latitude,
                Longitude = @event.Longitude,
                Timestamp = @event.Timestamp
            };

            _repositoryForCase.Insert(caseItem);
        }
    }
}
