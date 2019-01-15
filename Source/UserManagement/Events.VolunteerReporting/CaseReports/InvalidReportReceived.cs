/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.VolunteerReporting.CaseReports
{
    
    [Artifact("256396b8-bb23-4ef4-97ab-973575cb4ba6")]
    public class InvalidReportReceived : IEvent
    {
        public Guid DataCollectorId { get; }
        public DateTimeOffset Timestamp { get; }

        public InvalidReportReceived(Guid dataCollectorId, DateTimeOffset timestamp)
        {
            DataCollectorId = dataCollectorId;
            Timestamp = timestamp;
        }
    }
}