/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.Admin.Reporting.HealthRisks
{
    [Artifact("635304c5-c8aa-4b09-a968-408d2d81a08b")]
    public class NotificationReceived : IEvent
    {
        public Guid Id { get; }
        public string Message { get; }
        public string OriginNumber { get; }
        public DateTimeOffset Sent { get; }

        public NotificationReceived(Guid id, string message, string originNumber, DateTimeOffset sent)
        {
            Id = id;
            Message = message;
            OriginNumber = originNumber;
            Sent = sent;
        }
    }
}