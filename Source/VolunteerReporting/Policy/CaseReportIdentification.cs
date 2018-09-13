using Dolittle.Domain;
using Dolittle.Events.Processing;
using Domain;
using Events.External;
using Read.CaseReports;
using Read.DataCollectors;
using Read.InvalidCaseReports;
using Concepts.CaseReport;
using Concepts.DataCollector;
using Domain.CaseReports;

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

        public void Process(PhoneNumberAddedToDataCollector @event)
        {
            
            var unknownReports = this.unknownReports.GetByPhoneNumber(@event.PhoneNumber);
            var dataCollector = dataCollectors.GetById(@event.DataCollectorId); 
            foreach (var item in unknownReports)
            {
                var repo = caseReportingAggregateRootRepository.Get(item.Id.Value);
                repo.Report(
                    @event.DataCollectorId,
                    item.HealthRiskId,
                    item.Origin,
                    item.NumberOfMalesUnder5,
                    item.NumberOfMalesAged5AndOlder,
                    item.NumberOfFemalesUnder5,
                    item.NumberOfFemalesAged5AndOlder,
                    dataCollector.Location.Longitude,
                    dataCollector.Location.Latitude,
                    item.Timestamp,
                    item.Message
                    
                    );
                repo.ReportFromUnknownDataCollectorIdentiefied(@event.DataCollectorId);
            } 
            
            
            var invalidAndUnknownReports = this.invalidAndUnknownReports.GetByPhoneNumber(@event.PhoneNumber);
            foreach (var item in invalidAndUnknownReports)
            {
                var repo = caseReportingAggregateRootRepository.Get(item.Id.Value);
                repo.ReportInvalidReport(
                    @event.DataCollectorId,
                    item.PhoneNumber,
                    item.Message,
                    dataCollector.Location.Longitude,
                    dataCollector.Location.Latitude,
                    item.ParsingErrorMessage,
                    item.Timestamp
                    
                    );
                repo.ReportFromUnknownDataCollectorIdentiefied(@event.DataCollectorId);
            }
        }
    }
}
