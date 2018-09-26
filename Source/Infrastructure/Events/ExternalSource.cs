/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Events;
using Dolittle.Runtime.Events;

namespace Infrastructure.Events
{
    public class ExternalSource : EventSource
    {
        public ExternalSource(EventSourceId id) : base(id) { }
    }
}