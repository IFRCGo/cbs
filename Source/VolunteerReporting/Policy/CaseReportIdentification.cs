using doLittle.Domain;
using doLittle.Events.Processing;
using Domain;
using Events.External;
using Read.CaseReports;
using Read.DataCollectors;
using System.Threading.Tasks;

namespace Policy
{
    public class CaseReportIdentification : ICanProcessEvents
    {
        private readonly IAggregateRootRepositoryFor<CaseReporting> caseReportingAggregateRootRepository;
        private readonly ICaseReportsFromUnknownDataCollectors unknownReports;
        private readonly IDataCollectors dataCollectors;

        public CaseReportIdentification(
            IAggregateRootRepositoryFor<CaseReporting> caseReportingAggregateRootRepository,
            ICaseReportsFromUnknownDataCollectors unknownReports,
            IDataCollectors dataCollectors)
        {
            this.caseReportingAggregateRootRepository = caseReportingAggregateRootRepository;
            this.unknownReports = unknownReports;
            this.dataCollectors = dataCollectors;
        }

        public async Task Process(PhoneNumberAddedToDataCollector @event)
        {
            var unknownReports = await this.unknownReports.GetByPhoneNumber(@event.PhoneNumber);
            var dataCollector = this.dataCollectors.GetById(@event.DataCollectorId); 
            foreach (var item in unknownReports)
            {
                var repo = caseReportingAggregateRootRepository.Get(item.Id);
                repo.Report(
                    @event.DataCollectorId,
                    item.HealthRiskId,
                    item.Origin,
                    item.NumberOfMalesUnder5,
                    item.NumberOfMalesOver5,
                    item.NumberOfFemalesUnder5,
                    item.NumberOfFemalesOver5,
                    dataCollector.Location.Longitude,
                    dataCollector.Location.Latitude,
                    item.Timestamp
                    );
                repo.ReportFromUnknownDataCollectorIdentiefied(@event.DataCollectorId);
            }            
        }
    }
}
