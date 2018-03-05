using doLittle.Domain;
using doLittle.Events.Processing;
using Domain;
using Events.External;
using Read.CaseReports;
using System.Threading.Tasks;

namespace Policy
{
    public class CaseReportIdentification : ICanProcessEvents
    {
        private readonly IAggregateRootRepositoryFor<CaseReporting> caseReportingAggregateRootRepository;
        private readonly ICaseReportsFromUnknownDataCollectors unknownReports;

        public CaseReportIdentification(
            IAggregateRootRepositoryFor<CaseReporting> caseReportingAggregateRootRepository,
            ICaseReportsFromUnknownDataCollectors unknownReports)
        {
            this.caseReportingAggregateRootRepository = caseReportingAggregateRootRepository;
            this.unknownReports = unknownReports;
        }

        public async Task Process(PhoneNumberAddedToDataCollector @event)
        {
            var unknownReports = await this.unknownReports.GetByPhoneNumber(@event.PhoneNumber);
            foreach (var item in unknownReports)
            {
                var repo = caseReportingAggregateRootRepository.Get(item.Id);
                repo.Report(
                    @event.DataCollectorId,
                    item.HealthRiskId,
                    item.NumberOfMalesUnder5,
                    item.NumberOfMalesOver5,
                    item.NumberOfFemalesUnder5,
                    item.NumberOfFemalesOver5,
                    item.Location.Longitude,
                    item.Location.Latitude,
                    item.Timestamp
                    );
                repo.ReportFromUnknownDataCollectorIdentiefied(@event.DataCollectorId);
            }            
        }
    }
}
