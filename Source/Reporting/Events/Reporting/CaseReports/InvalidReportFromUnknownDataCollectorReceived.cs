/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Dolittle.Events;

namespace Events.Reporting.CaseReports
{
    public class InvalidReportFromUnknownDataCollectorReceived : IEvent
    {
        public Guid CaseReportId { get; }
        public string Origin { get; }
        public string Message { get; }
        public IEnumerable<string> ErrorMessages { get; }
        public DateTimeOffset Timestamp { get; }

        public InvalidReportFromUnknownDataCollectorReceived(Guid caseReportId, string origin, string message, IEnumerable<string> errorMessages, DateTimeOffset timestamp) 
        {
            CaseReportId = caseReportId;
            Origin = origin;
            Message = message;
            ErrorMessages = errorMessages;
            Timestamp = timestamp;               
        }
    }
}