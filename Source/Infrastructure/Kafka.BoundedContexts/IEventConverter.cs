/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using doLittle.Events;
using doLittle.Runtime.Events;

namespace Infrastructure.Kafka.BoundedContexts
{
    public interface IEventConverter
    {
        IEnumerable<EventContentAndEnvelope> Convert(IEnumerable<EventAndEnvelope> eventAndEnvelopes);
        IEnumerable<IEvent> Convert(IEnumerable<EventContentAndEnvelope> eventContentAndEnvelopes);
    }
}