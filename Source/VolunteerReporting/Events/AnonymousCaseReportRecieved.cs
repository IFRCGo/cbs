/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using doLittle.Events;
using System;

namespace Events
{
    public class AnonymousCaseReportRecieved : IEvent
    {
        public Guid Id { get; set; }
        public Guid HealthRiskId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public int NumberOfMalesUnder5 { get; set; }
        public int NumberOfMalesOver5 { get; set; }
        public int NumberOfFemalesUnder5 { get; set; }
        public int NumberOfFemalesOver5 { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
