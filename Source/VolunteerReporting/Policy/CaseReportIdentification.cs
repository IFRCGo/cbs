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
        private readonly ICaseReportsFromUnknownDataCollectors unknownCollectors;

        public CaseReportIdentification(
            IAggregateRootRepositoryFor<CaseReporting> caseReportingAggregateRootRepository,
            ICaseReportsFromUnknownDataCollectors unknownCollectors)
        {
            this.caseReportingAggregateRootRepository = caseReportingAggregateRootRepository;
            this.unknownCollectors = unknownCollectors;
        }

        public async Task Process(PhoneNumberAdded @event)
        {
            var unknownReports = await unknownCollectors.GetByPhoneNumber(@event.PhoneNumber);
            foreach (var item in unknownReports)
            {
                var repo = caseReportingAggregateRootRepository.Get(item.Id);
                repo.ReportFromUnknownDataCollectorIdentiefied(@event.DataCollectorId);
            }            
        }
    }
}
