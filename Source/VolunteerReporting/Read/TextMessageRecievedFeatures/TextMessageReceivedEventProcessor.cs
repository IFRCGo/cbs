/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Events.External;
using Read.TextMessageRecievedFeatures;

namespace Read.SmsRecievedFeatures
{
    public class TextMessageReceivedEventProcessor : Infrastructure.Events.IEventProcessor
    {
        readonly IReceivedTextMessages _receivedTextMessages;

        public TextMessageReceivedEventProcessor(IReceivedTextMessages receivedTextMessages)
        {
            _receivedTextMessages = receivedTextMessages;
        }

        public void Process(TextMessageReceived @event)
        {
            var message = _receivedTextMessages.GetById(@event.Id) ?? new RecievedTextMessage(@event.Id);
            message.Keyword = @event.Keyword;
            message.Message = @event.Message;
            message.OriginNumber = @event.OriginNumber;
            message.ReceivedAtGatewayNumber = @event.ReceivedAtGatewayNumber;
            message.Sent = @event.Sent;
            message.Latitude = @event.Latitude;
            message.Longitude = @event.Longitude;
            _receivedTextMessages.Save(message);
        }
    }
}
