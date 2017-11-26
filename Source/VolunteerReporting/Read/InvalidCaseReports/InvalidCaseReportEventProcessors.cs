using doLittle.Events.Processing;
using doLittle.Time;
using Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Read.InvalidCaseReports
{
    class InvalidCaseReportEventProcessors : ICanProcessEvents
    {
        readonly IInvalidCaseReports _invalidCaseReports;
        readonly IInvalidCaseReportsFromUnknownDataCollectors _invalidCaseReportsFromUnknownDataCollectors;
        readonly ISystemClock _systemClock;

        public InvalidCaseReportEventProcessors(
            IInvalidCaseReports invalidCaseReports,
            IInvalidCaseReportsFromUnknownDataCollectors invalidCaseReportsFromUnknownDataCollectors,
            ISystemClock systemClock)
        {
            _invalidCaseReports = invalidCaseReports;
            _invalidCaseReportsFromUnknownDataCollectors = invalidCaseReportsFromUnknownDataCollectors;
            _systemClock = systemClock;
        }


        public void Process(InvalidReportReceived @event)
        {
            var invalidCaseReport = new InvalidCaseReport(@event.CaseReportId);
            invalidCaseReport.DataCollectorId = @event.DataCollectorId;
            invalidCaseReport.Message = @event.Message;
            invalidCaseReport.ParsingErrorMessage = @event.ErrorMessages;
            invalidCaseReport.Timestamp = @event.Timestamp;
            _invalidCaseReports.Save(invalidCaseReport);
        }

        public void Process(InvalidReportFromUnknownDataCollectorReceived @event)
        {
            var invalidCaseReport = new InvalidCaseReportFromUnknownDataCollector(@event.CaseReportId);
            invalidCaseReport.PhoneNumber = @event.Origin;
            invalidCaseReport.Message = @event.Message;
            invalidCaseReport.ParsingErrorMessage = @event.ErrorMessages;
            invalidCaseReport.Timestamp = @event.Timestamp;
            _invalidCaseReportsFromUnknownDataCollectors.Save(invalidCaseReport);
        }
    }
}
