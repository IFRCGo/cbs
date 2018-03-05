/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Linq;
using System.Threading.Tasks;
using doLittle.Events;
using doLittle.Runtime.Events.Coordination;
using doLittle.Runtime.Transactions;
using doLittle.Types;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Infrastructure.Events.Web
{
    [Route("/api/events")]
    public class EventsController
    {
        readonly ITypeFinder _typeFinder;
        readonly IUncommittedEventStreamCoordinator _uncommittedEventStreamCoordinator;

        public EventsController(ITypeFinder typeFinder,
            IUncommittedEventStreamCoordinator uncommittedEventStreamCoordinator)
        {
            _uncommittedEventStreamCoordinator = uncommittedEventStreamCoordinator;
            _typeFinder = typeFinder;
        }

        [HttpPost]
        public async Task Post([FromBody] Event @event)
        {
            var eventType = _typeFinder.All.Where(type => type.Name == @event.Name).SingleOrDefault();
            if (eventType == null)
                throw new ArgumentException("Cannot resolve Event Type from Name - please check the name again");

            var serialized = JsonConvert.SerializeObject(@event.Content);
            var eventInstance = JsonConvert.DeserializeObject(serialized, eventType) as IEvent;

            var eventSource = new EventsControllerEventSource(@event.EventSourceId);
            eventSource.Apply(eventInstance);
            _uncommittedEventStreamCoordinator.Commit(
                TransactionCorrelationId.New(),
                eventSource.UncommittedEvents);

            await Task.CompletedTask;
        }
    }
}