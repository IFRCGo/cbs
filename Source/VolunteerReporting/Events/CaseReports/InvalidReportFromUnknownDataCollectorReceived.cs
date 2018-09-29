/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Dolittle.Events;

namespace Events.CaseReports
{
    public class InvalidReportFromUnknownDataCollectorReceived : IEvent
    {
        public InvalidReportFromUnknownDataCollectorReceived(Guid caseReportId, string origin, string message, IEnumerable<string> errorMessages, DateTimeOffset timestamp) 
        {
            this.CaseReportId = caseReportId;
            this.Origin = origin;
            this.Message = message;
            this.ErrorMessages = errorMessages;
            this.Timestamp = timestamp;
               
        }
        public Guid CaseReportId { get; }
        public string Origin { get; }
        public string Message { get; }
        public IEnumerable<string> ErrorMessages { get; }
        public DateTimeOffset Timestamp { get; }
    }
}