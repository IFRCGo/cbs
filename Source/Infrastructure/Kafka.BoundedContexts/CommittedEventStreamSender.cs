/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using doLittle.Collections;
using doLittle.Logging;
using doLittle.Runtime.Events;
using doLittle.Runtime.Events.Publishing;
using doLittle.Runtime.Events.Publishing.InProcess;
using doLittle.Serialization.Json;

namespace Kafka
{
    public delegate void EventReceived(string json);

    public class CommittedEventStreamSender : ICanSendCommittedEventStream
    {
        readonly IPublisher _publisher;
        readonly ICommittedEventStreamBridge _bridge;
        readonly IEventConverter _eventConverter;
        readonly ISerializer _serializer;
        readonly CommittedEventStreamSenderConfiguration _senderConfiguration;
        readonly ILogger _logger;

        public CommittedEventStreamSender(
            IPublisher publisher,
            ICommittedEventStreamBridge bridge,
            IEventConverter eventConverter,
            ISerializer serializer,
            CommittedEventStreamSenderConfiguration senderConfiguration,
            ILogger logger)
        {
            _publisher = publisher;
            _eventConverter = eventConverter;
            _bridge = bridge;
            _serializer = serializer;
            _senderConfiguration = senderConfiguration;
            _logger = logger;
        }

        public void Send(CommittedEventStream committedEventStream)
        {
            _logger.Information("Sending committed event stream");
            _bridge.Send(committedEventStream);
            var eventContentAndEnvelopes = _eventConverter.Convert(committedEventStream);
            var json = _serializer.ToJson(eventContentAndEnvelopes);

            _logger.Trace("Sending JSON : " + json);
            _senderConfiguration.Topics.ForEach(topic =>
            {
                _logger.Information($"Send committed event stream to topic: '{topic}'");
                _publisher.Publish(topic, json);
            });
        }
    }
}