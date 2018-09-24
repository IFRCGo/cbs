using Concepts.CaseReport;
using Dolittle.Events.Processing;
using Events;
using Events.CaseReports;
using Read.DataCollectors;
using Read.HealthRisks;

namespace Read.CaseReportsForListing
{
    public class CaseReportForListingEventProcessor : ICanProcessEvents
    {
        private readonly ICaseReportsForListing _caseReports;
        private readonly IDataCollectors _dataCollectors;
        private readonly IHealthRisks _healthRisks;

        public CaseReportForListingEventProcessor(
            ICaseReportsForListing caseReports,
            IDataCollectors dataCollectors,
            IHealthRisks healthRisks)
        {
            _caseReports = caseReports;
            _dataCollectors = dataCollectors;
            _healthRisks = healthRisks;
        }
        [EventProcessor("0d17954b-eaeb-4936-a7a6-153b61767206")]
        public void Process(CaseReportReceived @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            var healthRisk = _healthRisks.GetById(@event.HealthRiskId);

            _caseReports.SaveCaseReport(
                @event.CaseReportId,
                dataCollector,
                healthRisk,
                @event.Message,
                @event.Origin,
                @event.NumberOfMalesUnder5,
                @event.NumberOfMalesAged5AndOlder,
                @event.NumberOfFemalesUnder5,
                @event.NumberOfFemalesAged5AndOlder,
                @event.Timestamp);
        }

        //QUESTION: Should we also listen to datacollector and health risk changes to update names? Or is there a better way to do this?
        [EventProcessor("9b505b35-54e3-4e35-bccd-79d330de9c54")]
        public void Process(CaseReportFromUnknownDataCollectorReceived @event)
        {            
            var healthRisk = _healthRisks.GetById(@event.HealthRiskId);

            _caseReports.SaveCaseReportFromUnknownDataCollector(
                @event.CaseReportId,
                healthRisk,
                @event.Message,
                @event.Origin,
                @event.NumberOfMalesUnder5,
                @event.NumberOfMalesAged5AndOlder,
                @event.NumberOfFemalesUnder5,
                @event.NumberOfFemalesAged5AndOlder,
                @event.Timestamp);

        }
        [EventProcessor("c44c06e9-822f-41de-9d1e-0cdddcf1da0a")]
        public void Process(InvalidReportReceived @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);

            _caseReports.SaveInvalidReport(
                @event.CaseReportId,
                dataCollector,
                @event.Message,
                @event.Origin,
                @event.Latitude,
                @event.Longitude,
                @event.ErrorMessages,
                @event.Timestamp);
        }
        [EventProcessor("d4f5e727-c2fa-4140-b5de-d14ba3a22f13")]
        public void Process(InvalidReportFromUnknownDataCollectorReceived @event)
        {
            _caseReports.SaveInvalidReportFromUnknownDataCollector(
                @event.CaseReportId,
                @event.Message,
                @event.Origin,
                @event.ErrorMessages,
                @event.Timestamp);
        }
        [EventProcessor("46928d1f-987a-4a2d-804f-8e4b686d2262")]
        public void Process(CaseReportIdentified @event)
        {
            _caseReports.Delete(e => e.Id == (CaseReportId)@event.CaseReportId);
        }
    }
}
