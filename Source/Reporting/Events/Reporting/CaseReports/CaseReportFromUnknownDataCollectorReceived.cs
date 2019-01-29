/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.Reporting.CaseReports
{
    public class CaseReportFromUnknownDataCollectorReceived : IEvent
    {
        public Guid HealthRiskId { get; }
        public string Origin { get; }
        public string Message { get; }
        public DateTimeOffset Timestamp { get; }
        public int NumberOfMalesUnder5 { get; }
        public int NumberOfMalesAged5AndOlder { get; }
        public int NumberOfFemalesUnder5 { get; }
        public int NumberOfFemalesAged5AndOlder { get; }

        public CaseReportFromUnknownDataCollectorReceived(Guid healthRiskId, string origin, string message, DateTimeOffset timestamp, int numberOfMalesUnder5, int numberOfMalesAged5AndOlder, int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder) 
        {
            HealthRiskId = healthRiskId;
            Origin = origin;
            Message = message;
            Timestamp = timestamp;
            NumberOfMalesUnder5 = numberOfMalesUnder5;
            NumberOfMalesAged5AndOlder = numberOfMalesAged5AndOlder;
            NumberOfFemalesUnder5 = numberOfFemalesUnder5;
            NumberOfFemalesAged5AndOlder = numberOfFemalesAged5AndOlder;               
        }
    }
}