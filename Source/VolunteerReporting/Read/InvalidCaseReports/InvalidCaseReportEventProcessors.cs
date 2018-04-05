using Dolittle.Events.Processing;
using Dolittle.Time;
using Events;
using System;
using System.Collections.Generic;
using System.Text;
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


        public async Task Process(InvalidReportReceived @event)
        {
            // Send the invalid report to the DB
            var invalidCaseReport = new InvalidCaseReport(@event.CaseReportId);
            //invalidCaseReport.TextMessageId = @event.tex
            invalidCaseReport.DataCollectorId = @event.DataCollectorId;
            invalidCaseReport.Origin = @event.Origin;
            invalidCaseReport.Message = @event.Message;
            invalidCaseReport.ParsingErrorMessage = @event.ErrorMessages;
            invalidCaseReport.Timestamp = @event.Timestamp;
            await _invalidCaseReports.Save(invalidCaseReport);
        }

        public async Task Process(InvalidReportFromUnknownDataCollectorReceived @event)
        {
            // Send the invalid report to tbe DB
            var invalidCaseReport = new InvalidCaseReportFromUnknownDataCollector(@event.CaseReportId);
            invalidCaseReport.PhoneNumber = @event.Origin;
            invalidCaseReport.Message = @event.Message;
            invalidCaseReport.ParsingErrorMessage = @event.ErrorMessages;
            invalidCaseReport.Timestamp = @event.Timestamp;
            await _invalidCaseReportsFromUnknownDataCollectors.Save(invalidCaseReport);
        }

        public async Task Process(CaseReportIdentified @event)
        {
            await _invalidCaseReportsFromUnknownDataCollectors.Remove(@event.CaseReportId);
        }
    }
}
