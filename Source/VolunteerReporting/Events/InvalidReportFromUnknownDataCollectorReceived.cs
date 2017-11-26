/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using doLittle.Events;

namespace Events
{
    public class InvalidReportFromUnknownDataCollectorReceived : IEvent
    {
        public Guid CaseReportId { get; set; }
        public string Origin { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}