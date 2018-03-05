/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using doLittle.Runtime.Events;

namespace Infrastructure.Events.Web
{
    public class EventsControllerEventSource : EventSource
    {
        public EventsControllerEventSource(EventSourceId id) : base(id)
        {
        }
    }
}