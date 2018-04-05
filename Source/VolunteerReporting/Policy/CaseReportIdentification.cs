using Dolittle.Domain;
using Dolittle.Events.Processing;
using Domain;
using Events.External;
using Read.CaseReports;
using Read.DataCollectors;
using Read.InvalidCaseReports;
using System.Threading.Tasks;

namespace Policy
{
    public class CaseReportIdentification : ICanProcessEvents
    {
        private readonly IAggregateRootRepositoryFor<CaseReporting> caseReportingAggregateRootRepository;
        private readonly ICaseReportsFromUnknownDataCollectors unknownReports;
        private readonly IInvalidCaseReportsFromUnknownDataCollectors invalidAndUnknownReports;
        private readonly IDataCollectors dataCollectors;

        public CaseReportIdentification(
            IAggregateRootRepositoryFor<CaseReporting> caseReportingAggregateRootRepository,
            ICaseReportsFromUnknownDataCollectors unknownReports,
            IInvalidCaseReportsFromUnknownDataCollectors invalidAndUnknownReports,
            IDataCollectors dataCollectors)
        {
            this.caseReportingAggregateRootRepository = caseReportingAggregateRootRepository;
            this.unknownReports = unknownReports;
            this.invalidAndUnknownReports = invalidAndUnknownReports;
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
                    item.NumberOfMalesAges0To4,
                    item.NumberOfMalesAgedOver4,
                    item.NumberOfFemalesAges0To4,
                    item.NumberOfFemalesAgedOver4,
                    dataCollector.Location.Longitude,
                    dataCollector.Location.Latitude,
                    item.Timestamp
                    );
                repo.ReportFromUnknownDataCollectorIdentiefied(@event.DataCollectorId);
            } 
            
            var invalidAndUnknownReports = await this.invalidAndUnknownReports.GetByPhoneNumber(@event.PhoneNumber);
            foreach (var item in invalidAndUnknownReports)
            {
                var repo = caseReportingAggregateRootRepository.Get(item.Id);
                repo.ReportInvalidReport(
                    @event.DataCollectorId,
                    item.PhoneNumber,
                    item.Message,
                    item.ParsingErrorMessage,
                    item.Timestamp
                    );
                repo.ReportFromUnknownDataCollectorIdentiefied(@event.DataCollectorId);
            }
        }
    }
}
