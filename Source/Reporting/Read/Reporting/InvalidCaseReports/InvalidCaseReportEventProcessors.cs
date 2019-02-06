/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.CaseReports;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Dolittle.Runtime.Events;
using Events.Reporting.CaseReports;

namespace Read.Reporting.InvalidCaseReports
{
    public class InvalidCaseReportEventProcessors : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<InvalidCaseReport> _invalidCaseReports;
        readonly IReadModelRepositoryFor<InvalidCaseReportFromUnknownDataCollector> _invalidCaseReportsFromUnknownDataCollectors;

        public InvalidCaseReportEventProcessors(
            IReadModelRepositoryFor<InvalidCaseReport> invalidCaseReports,
            IReadModelRepositoryFor<InvalidCaseReportFromUnknownDataCollector> invalidCaseReportsFromUnknownDataCollectors)
        {
            _invalidCaseReports = invalidCaseReports;
            _invalidCaseReportsFromUnknownDataCollectors = invalidCaseReportsFromUnknownDataCollectors;
        }
        [EventProcessor("4d97e492-54f2-4637-99f1-1aa8686562ba")]
        public void Process(InvalidReportReceived @event, EventSourceId caseReportId)
        {
            var invalidCaseReport = new InvalidCaseReport(caseReportId.Value)
            {
                DataCollectorId = @event.DataCollectorId,
                Message = @event.Message,
                Origin = @event.Origin,
                ParsingErrorMessage = @event.ErrorMessages,
                Timestamp = @event.Timestamp
            };
            _invalidCaseReports.Insert(invalidCaseReport);
        }
        [EventProcessor("11f46b98-2b48-42d3-b060-ced0238822c0")]
        public void Process(InvalidReportFromUnknownDataCollectorReceived @event, EventSourceId caseReportId)
        {
            var invalidCaseReport = new InvalidCaseReportFromUnknownDataCollector(caseReportId.Value)
            {
                Message = @event.Message,
                ParsingErrorMessage = @event.ErrorMessages,
                PhoneNumber = @event.Origin,
                Timestamp = @event.Timestamp
            };
            _invalidCaseReportsFromUnknownDataCollectors.Insert(invalidCaseReport);
        }
        [EventProcessor("06a22439-570f-4cbf-ba34-b5e874b96a2c")]
        public void Process(CaseReportIdentified @event, EventSourceId caseReportId)
        {
            var caseReport = _invalidCaseReportsFromUnknownDataCollectors.GetById(caseReportId.Value);
            _invalidCaseReportsFromUnknownDataCollectors.Delete(caseReport);
        }
    }
}