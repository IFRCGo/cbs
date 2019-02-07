using Concepts.CaseReports;
using Dolittle.Collections;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Dolittle.Types;
using Events.Reports;

namespace Read.Reports
{
    public partial class ReportEventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<Report> _repositoryForCase;
        private readonly IInstancesOf<IReportNotificationService> _services;

        public ReportEventProcessor(
            IReadModelRepositoryFor<Report> repositoryForCase,
            IInstancesOf<IReportNotificationService> services
        )
        {
            _repositoryForCase = repositoryForCase;
            _services = services;
        }
        
        [EventProcessor("d6fd94bf-8d64-4403-bc51-0601e9b80dd6")]
        public void Process(ReportRegistered @event)
        {
            var item = new Report(@event.ReportId)
            {
                CaseReportId = @event.CaseReportId,
                DataCollectorId = @event.DataCollectorId,
                OriginPhoneNumber = @event.OriginPhoneNumber,
                AgeGroup = (AgeGroup)@event.AgeGroup,
                Sex = (Sex)@event.Sex,
                HealthRiskId = @event.HealthRiskId,
                HealthRiskNumber = @event.HealthRiskNumber,
                Latitude = @event.Latitude,
                Longitude = @event.Longitude,
                Timestamp = @event.Timestamp
            };

            _repositoryForCase.Insert(item);
            _services.ForEach(s => s.Changed(item));
        }
    }
}
