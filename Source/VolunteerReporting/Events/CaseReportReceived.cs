/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Events;

namespace Events
{
    public class CaseReportReceived : IEvent
    {        
        public Guid CaseReportId { get; set; }
        public Guid DataCollectorId { get; set; }
        public Guid HealthRiskId { get; set; }
        public string Origin { get; set; }
        public int NumberOfMalesAges0To4 { get; set; }
        public int NumberOfMalesAgedOver4 { get; set; }
        public int NumberOfFemalesAges0To4 { get; set; }
        public int NumberOfFemalesAgedOver4 { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}