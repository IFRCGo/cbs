/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using System.Collections.Generic;
using Events.Reporting.CaseReports;

namespace Domain.Reporting.CaseReports
{
    public class CaseReporting : AggregateRoot
    {
        public CaseReporting(EventSourceId eventSourceId) : base(eventSourceId)
        {
        }

        public void ReportInvalidReport(
            Guid collector,
            string origin,
            string originalMessage,
            double longitude,
            double latitude,
            IEnumerable<string> errorMessages,
            DateTimeOffset timestamp)
        {
            Apply(new InvalidReportReceived(collector, origin, originalMessage, longitude, latitude, errorMessages, timestamp));
        }

        public void ReportInvalidReportFromUnknownDataCollector(
            string origin,
            string originalMessage,
            IEnumerable<string> errorMessages,
            DateTimeOffset timestamp)
        {
            Apply(new InvalidReportFromUnknownDataCollectorReceived(origin, originalMessage, errorMessages, timestamp));

        }

        public void Report(
            Guid dataCollectorId,
            Guid healthRiskId,
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
            Apply(new CaseReportReceived(dataCollectorId, healthRiskId, origin, message, 
                numberOfMalesUnder5, numberOfMalesAged5AndOlder, numberOfFemalesUnder5, numberOfFemalesAged5AndOlder,
                longitude, latitude, timestamp));
        }        

        public void ReportFromUnknownDataCollector(
            string origin,
            Guid healthRiskId,
            int numberOfMalesUnder5,
            int numberOfMalesAged5AndOlder,
            int numberOfFemalesUnder5,
            int numberOfFemalesAged5AndOlder,
            DateTimeOffset timestamp,
            string message)
        {
            Apply(new CaseReportFromUnknownDataCollectorReceived(healthRiskId, origin, message, timestamp,
                numberOfMalesUnder5, numberOfMalesAged5AndOlder, numberOfFemalesUnder5, numberOfFemalesAged5AndOlder));
        }      
        
        public void ReportFromUnknownDataCollectorIdentiefied(
            Guid dataCollectorId
        )
        {
            Apply(new CaseReportIdentified(dataCollectorId));
        }
    }
}