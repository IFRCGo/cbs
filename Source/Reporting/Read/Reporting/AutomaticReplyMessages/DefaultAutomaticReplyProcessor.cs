/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.AutomaticReplies;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Admin.Reporting.DefaultReplyMessages;

namespace Read.Reporting.AutomaticReplyMessages
{
    public class DefaultAutomaticReplyProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<DefaultAutomaticReply> _defaultAutomaticReplies;
        private readonly IReadModelRepositoryFor<DefaultAutomaticReplyKeyMessage> _defaultKeyMessages;

        public DefaultAutomaticReplyProcessor(IReadModelRepositoryFor<DefaultAutomaticReply> defaultAutomaticReplies, IReadModelRepositoryFor<DefaultAutomaticReplyKeyMessage> defaultKeyMessages)
        {
            _defaultAutomaticReplies = defaultAutomaticReplies;
            _defaultKeyMessages = defaultKeyMessages;
        }
        [EventProcessor("9e039492-a02f-4ffd-b99c-e745618f3f80")]
        public void Process(DefaultAutomaticReplyDefined @event)
        {
            var reply = _defaultAutomaticReplies.GetById(@event.Id);
            if(reply == null)
            {
                reply = new DefaultAutomaticReply(@event.Id)
                {
                    Language = @event.Language,
                    Message = @event.Message,
                    Type = (AutomaticReplyType) @event.Type
                };

                _defaultAutomaticReplies.Insert(reply);
            }
            else
            {
                reply.Language = @event.Language;
                reply.Message = @event.Message;
                reply.Type = (AutomaticReplyType)@event.Type;

                _defaultAutomaticReplies.Update(reply);
            }
        }
        [EventProcessor("5c591794-d3ac-4190-bbbc-d7f7445a8967")]
        public void Process(DefaultAutomaticReplyKeyMessageDefined @event)
        {
            var message = _defaultKeyMessages.GetById(@event.Id);
            if (message == null)
            {
                message = new DefaultAutomaticReplyKeyMessage(@event.Id)
                {
                    Type = (AutomaticReplyKeyMessageType) @event.Type,
                    Language = @event.Language,
                    Message = @event.Message,
                    HealthRiskId = @event.HealthRiskId
                };

                _defaultKeyMessages.Insert(message);
            }
            else
            {
                message.Type = (AutomaticReplyKeyMessageType) @event.Type;
                message.Language = @event.Language;
                message.Message = @event.Message;
                message.HealthRiskId = @event.HealthRiskId;

                _defaultKeyMessages.Update(message);
            }
        }
    }
}
