/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Dolittle.Events;

namespace Infrastructure.Events
{
    public interface IEventReplayer
    {
        void Replay<T>(IEnumerable<T> events, Func<T, Guid> getIdCallback, Action<IEventSource, T> eventSourceCallback = null) where T : IEvent;
    }
}