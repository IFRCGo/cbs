using System;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Concepts;
using Events;
using System.Collections.Generic;

namespace Domain
{
    public class CaseReporting : AggregateRoot
    {
        public CaseReporting(EventSourceId eventSourceId) : base(eventSourceId)
        {
        }

        public void ReportInvalidReport(
            DataCollectorId collector,
            string origin,
            string originalMessage,
            IEnumerable<string> errorMessages,
            DateTimeOffset timestamp)
        {
            Apply(new InvalidReportReceived
            {
                CaseReportId = EventSourceId,
                DataCollectorId = collector,
                Origin = origin,
                Message = originalMessage,
                ErrorMessages = errorMessages,
                Timestamp = timestamp
            });
        }

        public void ReportInvalidReportFromUnknownDataCollector(
            string origin,
            string originalMessage,
            IEnumerable<string> errorMessages,
            DateTimeOffset timestamp)
        {
            Apply(new InvalidReportFromUnknownDataCollectorReceived
            {
                CaseReportId = EventSourceId,
                Origin = origin,
                Message = originalMessage,
                ErrorMessages = errorMessages,
                Timestamp = timestamp
            });

        }

        public void Report(
            Guid dataCollectorId,
            Guid healthRiskId,
            string origin,
            int numberOfMalesAges0To4,
            int numberOfMalesAgedOver4,
            int numberOfFemalesAges0To4,
            int numberOfFemalesAgedOver4,
            double longitude,
            double latitude,
            DateTimeOffset timestamp)
        {
            Apply(new CaseReportReceived
            {
                CaseReportId = EventSourceId,
                DataCollectorId = dataCollectorId,
                HealthRiskId = healthRiskId,
                Origin = origin,
                NumberOfMalesAges0To4 = numberOfMalesAges0To4,
                NumberOfMalesAgedOver4 = numberOfMalesAgedOver4,
                NumberOfFemalesAges0To4 = numberOfFemalesAges0To4,
                NumberOfFemalesAgedOver4 = numberOfFemalesAgedOver4,
                Longitude = longitude,
                Latitude = latitude,
                Timestamp = timestamp
            });
        }        

        public void ReportFromUnknownDataCollector(
            string origin,
            Guid healthRiskId,
            int numberOfMalesAges0To4,
            int numberOfMalesAgedOver4,
            int numberOfFemalesAges0To4,
            int numberOfFemalesAgedOver4,
            DateTimeOffset timestamp)
        {
            Apply(new CaseReportFromUnknownDataCollectorReceived
            {
                CaseReportId = EventSourceId,
                Origin = origin,
                HealthRiskId = healthRiskId,
                NumberOfFemalesAges0To4 = numberOfFemalesAges0To4,
                NumberOfFemalesAgedOver4 = numberOfFemalesAgedOver4,
                NumberOfMalesAges0To4 = numberOfMalesAges0To4,
                NumberOfMalesAgedOver4 = numberOfMalesAgedOver4,
                Timestamp = timestamp
            });
        }      
        
        public void ReportFromUnknownDataCollectorIdentiefied(
            Guid DataCollectorId
            )
        {
            Apply(new CaseReportIdentified
            {
                CaseReportId = EventSourceId,
                DataCollectorId = DataCollectorId
            });
        }
    }
}