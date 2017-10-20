/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Events;
using Events.External;
using Infrastructure.Application;
using Infrastructure.Events;
using Read;
using Read.HealthRiskFeatures;
using System;
using Read.TextMessageRecievedFeatures;

namespace Read.TextMessageRecievedFeatures
{
    public class TextMessageReceivedStorageProcessor : Infrastructure.Events.IEventProcessor
    {
        readonly IReceivedTextMessages _receivedTextMessages;

        public TextMessageReceivedStorageProcessor(
            IReceivedTextMessages receivedTextMessages,
            IEventEmitter eventEmitter,
            IDataCollectors dataCollectors,
            IHealthRisks healthRisks)
        {
            _receivedTextMessages = receivedTextMessages;
        }

        //TODO: Add test that sends TextMessageReceived events and verifies that the correct events are emitted
        public void Process(TextMessageReceived @event)
        {            
            var message = _receivedTextMessages.GetById(@event.Id) ?? new ReceivedTextMessage(@event.Id);
            message.Keyword = @event.Keyword;
            message.Message = @event.Message;
            message.OriginNumber = @event.OriginNumber;
            message.ReceivedAtGatewayNumber = @event.ReceivedAtGatewayNumber;
            message.Sent = @event.Sent;
            message.Location = new Location(@event.Latitude, @event.Longitude);
            _receivedTextMessages.Save(message);            
        }


    }
}
