/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.Reporting.DataCollectors
{
    [Artifact("899f24ac-860d-4dae-ae90-938ac12e5226", 1)]
    public class DataCollectorRegistered : IEvent
    {
        public DataCollectorRegistered (
                string region,
                string district,
                DateTimeOffset registeredAt
            )
        {
            Region = region;
            District = district;
            RegisteredAt = registeredAt;
        }
        public DateTimeOffset RegisteredAt { get; }
        public string Region { get; }
        public string District { get; }
    }
}