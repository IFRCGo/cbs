/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Dolittle.Events;

namespace Events.Reporting.CaseReports
{
    public class InvalidReportReceived : IEvent
    {
        public Guid DataCollectorId { get; }
        public string Origin { get; }
        public string Message { get; }
        public double Longitude { get; }
        public double Latitude { get; }
        public IEnumerable<string> ErrorMessages { get; }
        public DateTimeOffset Timestamp { get; }

        public InvalidReportReceived(Guid dataCollectorId, string origin, 
            string message, double longitude, double latitude, IEnumerable<string> errorMessages, DateTimeOffset timestamp) 
        {
            DataCollectorId = dataCollectorId;
            Origin = origin;
            Message = message;
            Longitude = longitude;
            Latitude = latitude;
            ErrorMessages = errorMessages;
            Timestamp = timestamp;               
        }
    }
}