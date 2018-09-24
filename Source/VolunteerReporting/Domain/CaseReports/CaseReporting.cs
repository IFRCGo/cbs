using System;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Concepts.DataCollector;
using Concepts.HealthRisk;
using Events;
using System.Collections.Generic;
using Events.CaseReports;

namespace Domain.CaseReports
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
            double longitude,
            double latitude,
            IEnumerable<string> errorMessages,
            DateTimeOffset timestamp)
        {
            Apply(new InvalidReportReceived(EventSourceId, collector, origin, originalMessage, longitude, latitude, timestamp));
        }

        public void ReportInvalidReportFromUnknownDataCollector(
            string origin,
            string originalMessage,
            IEnumerable<string> errorMessages,
            DateTimeOffset timestamp)
        {
            Apply(new InvalidReportFromUnknownDataCollectorReceived(EventSourceId, origin, originalMessage, errorMessages, timestamp));

        }

        public void Report(
            DataCollectorId dataCollectorId,
            HealthRiskId healthRiskId,
            string origin,
            int numberOfMalesUnder5,
            int numberOfMalesAged5AndOlder,
            int numberOfFemalesUnder5,
            int numberOfFemalesAged5AndOlder,
            double longitude,
            double latitude,
            DateTimeOffset timestamp,
            string message)
        {
            Apply(new CaseReportReceived(EventSourceId, dataCollectorId, healthRiskId, origin, message, 
                numberOfMalesUnder5, numberOfMalesAged5AndOlder, numberOfFemalesUnder5, numberOfFemalesAged5AndOlder,
                longitude, latitude, timestamp));
        }        

        public void ReportFromUnknownDataCollector(
            string origin,
            HealthRiskId healthRiskId,
            int numberOfMalesUnder5,
            int numberOfMalesAged5AndOlder,
            int numberOfFemalesUnder5,
            int numberOfFemalesAged5AndOlder,
            DateTimeOffset timestamp,
            string message)
        {
            Apply(new CaseReportFromUnknownDataCollectorReceived(EventSourceId, healthRiskId, origin, message, timestamp,
                numberOfMalesUnder5, numberOfMalesAged5AndOlder, numberOfFemalesUnder5, numberOfFemalesAged5AndOlder));
        }      
        
        public void ReportFromUnknownDataCollectorIdentiefied(
            DataCollectorId dataCollectorId
            )
        {
            Apply(new CaseReportIdentified(EventSourceId, dataCollectorId));
        }
    }
}