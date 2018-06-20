using Dolittle.Events.Processing;
using Events;

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

        public void Process(InvalidReportFromUnknownDataCollectorReceived @event)
        {
            _invalidCaseReportsFromUnknownDataCollectors.SaveInvalidReportFromUnknownDataCollector(
                @event.CaseReportId,
                @event.Message,
                @event.Origin,
                @event.ErrorMessages,
                @event.Timestamp);
        }

        public void Process(CaseReportIdentified @event)
        {
            _invalidCaseReportsFromUnknownDataCollectors.Delete(r => r.Id.Value == @event.CaseReportId);
        }
    }
}
