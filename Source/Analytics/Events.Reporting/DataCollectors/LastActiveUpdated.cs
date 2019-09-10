/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
 
using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.Reporting.DataCollectors
{
    [Artifact("d55c4484-cf1c-4c66-92c7-0f953cb2344d", 1)]
    public class LastActiveUpdated : IEvent
    {
        public DateTimeOffset LastActive { get; }

        public LastActiveUpdated(DateTimeOffset lastActive)
        {
            LastActive = lastActive;
        }
    }
}
