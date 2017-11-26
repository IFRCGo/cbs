/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using doLittle.Events;

namespace Events
{
    public class CaseReportReceived : IEvent
    {
        public DateTimeOffset Timestamp { get; set; }
        public Guid CaseReportId { get; set; }
        public Guid DataCollectorId { get; set; }
        public Guid HealthRiskId { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}