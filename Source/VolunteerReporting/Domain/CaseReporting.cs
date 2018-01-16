using System;
using doLittle.Domain;
using doLittle.Runtime.Events;
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
            string originalMessage,
            IEnumerable<string> errorMessages,
            DateTimeOffset timestamp)
        {
            Apply(new InvalidReportReceived
            {
                CaseReportId = EventSourceId,
                DataCollectorId = collector,
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
            int numberOfMalesUnder5,
            int numberOfMalesOver5,
            int numberOfFemalesUnder5,
            int numberOfFemalesOver5,
            double longitude,
            double latitude,
            DateTimeOffset timestamp)
        {
            Apply(new CaseReportReceived
            {
                CaseReportId = EventSourceId,
                DataCollectorId = dataCollectorId,
                HealthRiskId = healthRiskId,
                NumberOfMalesUnder5 = numberOfMalesUnder5,
                NumberOfMalesOver5 = numberOfMalesOver5,
                NumberOfFemalesUnder5 = numberOfFemalesUnder5,
                NumberOfFemalesOver5 = numberOfFemalesOver5,
                Longitude = longitude,
                Latitude = latitude,
                Timestamp = timestamp
            });
        }        

        public void ReportFromUnknownDataCollector(
            string origin,
            Guid healthRiskId,
            int numberOfMalesUnder5,
            int numberOfMalesOver5,
            int numberOfFemalesUnder5,
            int numberOfFemalesOver5,
            double longitude,
            double latitude,
            DateTimeOffset timestamp)
        {
            Apply(new CaseReportFromUnknownDataCollectorReceived
            {
                CaseReportId = EventSourceId,
                Origin = origin,
                HealthRiskId = healthRiskId,
                NumberOfFemalesUnder5 = numberOfFemalesUnder5,
                NumberOfFemalesOver5 = numberOfFemalesOver5,
                NumberOfMalesUnder5 = numberOfMalesUnder5,
                NumberOfMalesOver5 = numberOfMalesOver5,
                Longitude = longitude,
                Latitude = latitude,
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