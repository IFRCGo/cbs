/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.CaseReports
{
    [Artifact("30c0e44c-0ef8-4a1e-a726-ee755b09e3d8")]
    public class CaseReportReceived : IEvent
    {
        public Guid CaseReportId { get; }
        public Guid DataCollectorId { get; }
        public Guid HealthRiskId { get; }
        public string Origin { get; }
        public string Message { get; }
        public int NumberOfMalesUnder5 { get; }
        public int NumberOfMalesAged5AndOlder { get; }
        public int NumberOfFemalesUnder5 { get; }
        public int NumberOfFemalesAged5AndOlder { get; }
        public double Longitude { get; }
        public double Latitude { get; }
        public DateTimeOffset Timestamp { get; }

        public CaseReportReceived(Guid caseReportId, Guid dataCollectorId, Guid healthRiskId, 
            string origin, string message, int numberOfMalesUnder5, int numberOfMalesAged5AndOlder, 
            int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder, double longitude, 
            double latitude, DateTimeOffset timestamp) 
        {
            CaseReportId = caseReportId;
            DataCollectorId = dataCollectorId;
            HealthRiskId = healthRiskId;
            Origin = origin;
            Message = message;
            NumberOfMalesUnder5 = numberOfMalesUnder5;
            NumberOfMalesAged5AndOlder = numberOfMalesAged5AndOlder;
            NumberOfFemalesUnder5 = numberOfFemalesUnder5;
            NumberOfFemalesAged5AndOlder = numberOfFemalesAged5AndOlder;
            Longitude = longitude;
            Latitude = latitude;
            Timestamp = timestamp;               
        }
    }
}