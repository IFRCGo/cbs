using Concepts;
using Dolittle.Collections;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Dolittle.Types;
using Events.CaseReports;

namespace Read.CaseReports
{
    public partial class CaseEventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<Case> _repositoryForCase;
        private readonly IInstancesOf<ICaseNotificationService> _services;

        public CaseEventProcessor(
            IReadModelRepositoryFor<Case> repositoryForCase,
            IInstancesOf<ICaseNotificationService> services
        )
        {
            _repositoryForCase = repositoryForCase;
            _services = services;
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
            _services.ForEach(s => s.Changed(caseItem));
        }
    }
}
