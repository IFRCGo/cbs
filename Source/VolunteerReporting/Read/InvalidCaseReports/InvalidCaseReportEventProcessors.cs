using Concepts.CaseReport;
using Dolittle.Events.Processing;
using Events;
using Events.CaseReports;

namespace Read.InvalidCaseReports
{
    public class InvalidCaseReportEventProcessors : ICanProcessEvents
    {
        readonly IInvalidCaseReports _invalidCaseReports;
        readonly IInvalidCaseReportsFromUnknownDataCollectors _invalidCaseReportsFromUnknownDataCollectors;

        public InvalidCaseReportEventProcessors(
            IInvalidCaseReports invalidCaseReports,
            IInvalidCaseReportsFromUnknownDataCollectors invalidCaseReportsFromUnknownDataCollectors)
        {
            _invalidCaseReports = invalidCaseReports;
            _invalidCaseReportsFromUnknownDataCollectors = invalidCaseReportsFromUnknownDataCollectors;
        }
        [EventProcessor("4d97e492-54f2-4637-99f1-1aa8686562ba")]
        public void Process(InvalidReportReceived @event)
        {
            _invalidCaseReports.SaveInvalidReport(
                @event.CaseReportId,
                @event.DataCollectorId,
                @event.Message,
                @event.Origin,
                @event.ErrorMessages,
                @event.Timestamp);
        }
        [EventProcessor("11f46b98-2b48-42d3-b060-ced0238822c0")]
        public void Process(InvalidReportFromUnknownDataCollectorReceived @event)
        {
            _invalidCaseReportsFromUnknownDataCollectors.SaveInvalidReportFromUnknownDataCollector(
                @event.CaseReportId,
                @event.Message,
                @event.Origin,
                @event.ErrorMessages,
                @event.Timestamp);
        }
        [EventProcessor("06a22439-570f-4cbf-ba34-b5e874b96a2c")]
        public void Process(CaseReportIdentified @event)
        {
            _invalidCaseReportsFromUnknownDataCollectors.Delete(r => r.Id == (CaseReportId)@event.CaseReportId);
        }
    }
}
