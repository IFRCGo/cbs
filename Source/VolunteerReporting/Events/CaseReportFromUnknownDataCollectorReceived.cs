/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using doLittle.Events;

namespace Events
{
    public class CaseReportFromUnknownDataCollectorReceived : IEvent
    {
        public Guid CaseReportId { get; set; }
        public Guid HealthRiskId { get; set; }
        public string Origin { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public int NumberOfMalesUnder5 { get; set; }
        public int NumberOfMalesAged5AndOlder { get; set; }
        public int NumberOfFemalesUnder5 { get; set; }
        public int NumberOfFemalesAged5AndOlder { get; set; }       
    }
}
