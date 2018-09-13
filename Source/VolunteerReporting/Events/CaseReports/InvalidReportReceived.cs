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
        public Guid CaseReportId { get; set; }
        public Guid DataCollectorId { get; set; }
        public string Origin { get; set; }
        public string Message { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}