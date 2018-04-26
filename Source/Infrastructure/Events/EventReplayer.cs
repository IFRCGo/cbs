/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Dolittle.Collections;
using Dolittle.Events;
using Dolittle.Logging;
using Dolittle.Runtime.Events.Coordination;
using Dolittle.Runtime.Transactions;

namespace Infrastructure.Events
{
    public class EventReplayer : IEventReplayer
    {
        readonly IUncommittedEventStreamCoordinator _uncommittedEventStreamCoordinator;
        readonly ILogger _logger;

        public EventReplayer(IUncommittedEventStreamCoordinator uncommittedEventStreamCoordinator, ILogger logger)
        {
            _uncommittedEventStreamCoordinator = uncommittedEventStreamCoordinator;
            _logger = logger;
        }
        
        public void Replay<T>(
            IEnumerable<T> events,
            Func<T, Guid> getIdCallback,
            Action<IEventSource, T> eventSourceCallback = null) where T : IEvent
        {
            events.ForEach(@event => {
                try 
                {
                    var eventSource = new ExternalSource(getIdCallback(@event));
                    eventSource.Apply(@event);
                    if( eventSourceCallback != null ) eventSourceCallback(eventSource, @event);
                    _uncommittedEventStreamCoordinator.Commit(TransactionCorrelationId.New(), eventSource.UncommittedEvents);
                } catch( Exception exception )
                {
                    _logger.Error(exception, "Problem applying event");
                }
            });
        }
    }
}