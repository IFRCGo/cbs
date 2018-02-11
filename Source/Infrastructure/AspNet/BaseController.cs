/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using doLittle.Events;
using doLittle.Runtime.Events;
using doLittle.Runtime.Events.Coordination;
using doLittle.Runtime.Transactions;

namespace Infrastructure.AspNet
{
    /// <summary>
    /// Represents a base <see cref="Microsoft.AspNetCore.Mvc.Controller">controller</see>
    /// with reusable functionality
    /// </summary>
    public class BaseController : Microsoft.AspNetCore.Mvc.Controller
    {
        readonly IUncommittedEventStreamCoordinator _uncommittedEventStreamCoordinator;

        readonly Dictionary<EventSourceId, IEventSource> _eventSourceById =
            new Dictionary<EventSourceId, IEventSource>();


        /// <summary>
        /// Initializes a new instance of <see cref="EventEmitter"/>
        /// </summary>
        public BaseController()
        {
            _uncommittedEventStreamCoordinator =
                Internals.ServiceProvider.GetService(typeof(IUncommittedEventStreamCoordinator)) as
                    IUncommittedEventStreamCoordinator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventSourceId"></param>
        /// <param name="@event"></param>
        protected void Apply(EventSourceId eventSourceId, IEvent @event)
        {
            var transactionCorrelationId = TransactionCorrelationId.New();
            var eventSource = GetEventSourceForThisController(eventSourceId);
            eventSource.Apply(@event);
            _uncommittedEventStreamCoordinator.Commit(transactionCorrelationId, eventSource.UncommittedEvents);
        }

        IEventSource GetEventSourceForThisController(EventSourceId eventSourceId)
        {
            if (_eventSourceById.ContainsKey(eventSourceId)) return _eventSourceById[eventSourceId];

            var eventSource = new ControllerAggregateRoot(eventSourceId);
            _eventSourceById[eventSourceId] = eventSource;
            return eventSource;
        }
    }
}