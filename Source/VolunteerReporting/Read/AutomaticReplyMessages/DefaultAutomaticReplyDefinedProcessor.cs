using Concepts;
using doLittle.Events.Processing;
using Events.External;
using System;
using System.Collections.Generic;
using System.Text;

namespace Read.AutomaticReplyMessages
{
    public class DefaultAutomaticReplyDefinedProcessor : ICanProcessEvents
    {
        private readonly IDefaultAutomaticReplies _defaultAutomaticReplies;
        private readonly IDefaultAutomaticReplyKeyMessages _defaultKeyMessages;

        public DefaultAutomaticReplyDefinedProcessor(IDefaultAutomaticReplies defaultAutomaticReplies, IDefaultAutomaticReplyKeyMessages defaultKeyMessages)
        {
            _defaultAutomaticReplies = defaultAutomaticReplies;
            _defaultKeyMessages = defaultKeyMessages;
        }

        public void Process(DefaultAutomaticReplyDefined @event)
        {
            var automaticReply = _defaultAutomaticReplies.GetByTypeAndLanguage((AutomaticReplyType)@event.Type, @event.Language) ?? new DefaultAutomaticReply(@event.Id);
            automaticReply.Id = @event.Id;
            automaticReply.Type = (AutomaticReplyType)@event.Type;
            automaticReply.Message = @event.Message;
            automaticReply.Language = @event.Language;
            _defaultAutomaticReplies.Save(automaticReply);
        }

        public void Process(DefaultAutmaicReplyKeyMessageDefined @event)
        {
            var keyMessage = _defaultKeyMessages.GetByTypeLanguageAndHealthRisk((AutomaticReplyKeyMessageType)@event.Type, @event.Language, @event.HealthRiskId) ?? new DefaultAutomaticReplyKeyMessage(@event.Id);
            keyMessage.Id = @event.Id;
            keyMessage.Type = (AutomaticReplyKeyMessageType)@event.Type;
            keyMessage.Message = @event.Message;
            keyMessage.Language = @event.Language;
            _defaultKeyMessages.Save(keyMessage);
        }

    }
}
