using Dolittle.Events.Processing;
using Dolittle.Time;
using Events;
using System.Threading.Tasks;

namespace Read.InvalidCaseReports
{
    class InvalidCaseReportEventProcessors : ICanProcessEvents
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
            // Send the invalid report to the DB
            var invalidCaseReport = new InvalidCaseReport(@event.CaseReportId);
            //invalidCaseReport.TextMessageId = @event.tex
            invalidCaseReport.DataCollectorId = @event.DataCollectorId;
            invalidCaseReport.Origin = @event.Origin;
            invalidCaseReport.Message = @event.Message;
            invalidCaseReport.ParsingErrorMessage = @event.ErrorMessages;
            invalidCaseReport.Timestamp = @event.Timestamp;
            _invalidCaseReports.Save(invalidCaseReport);
        }

        public void Process(InvalidReportFromUnknownDataCollectorReceived @event)
        {
            // Send the invalid report to tbe DB
            var invalidCaseReport =
                new InvalidCaseReportFromUnknownDataCollector(@event.CaseReportId)
                {
                    PhoneNumber = @event.Origin,
                    Message = @event.Message,
                    ParsingErrorMessage = @event.ErrorMessages,
                    Timestamp = @event.Timestamp
                };
            _invalidCaseReportsFromUnknownDataCollectors.Save(invalidCaseReport);
        }

        public void Process(CaseReportIdentified @event)
        {
            _invalidCaseReportsFromUnknownDataCollectors.Remove(@event.CaseReportId);
        }
    }
}
