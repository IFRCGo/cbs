/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Dolittle.Events;

namespace Events.CaseReports
{
    public class InvalidReportReceived : IEvent
    {
        public InvalidReportReceived(Guid caseReportId, Guid dataCollectorId, string origin, 
            string message, double longitude, double latitude, IEnumerable<string> errorMessages, DateTimeOffset timestamp) 
        {
            this.CaseReportId = caseReportId;
            this.DataCollectorId = dataCollectorId;
            this.Origin = origin;
            this.Message = message;
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.ErrorMessages = errorMessages;
            this.Timestamp = timestamp;
               
        }
        public Guid CaseReportId { get; }
        public Guid DataCollectorId { get; }
        public string Origin { get; }
        public string Message { get; }
        public double Longitude { get; }
        public double Latitude { get; }
        public IEnumerable<string> ErrorMessages { get; }
        public DateTimeOffset Timestamp { get; }
    }
}