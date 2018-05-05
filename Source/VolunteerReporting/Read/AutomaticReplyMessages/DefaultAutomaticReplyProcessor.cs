using Concepts;
using Dolittle.Events.Processing;
using Events.External;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Read.AutomaticReplyMessages
{
    public class DefaultAutomaticReplyProcessor : ICanProcessEvents
    {
        private readonly IDefaultAutomaticReplies _defaultAutomaticReplies;
        private readonly IDefaultAutomaticReplyKeyMessages _defaultKeyMessages;

        public DefaultAutomaticReplyProcessor(IDefaultAutomaticReplies defaultAutomaticReplies, IDefaultAutomaticReplyKeyMessages defaultKeyMessages)
        {
            _defaultAutomaticReplies = defaultAutomaticReplies;
            _defaultKeyMessages = defaultKeyMessages;
        }

        public async Task Process(DefaultAutomaticReplyDefined @event)
        {
            var automaticReply = _defaultAutomaticReplies.GetByTypeAndLanguage((AutomaticReplyType)@event.Type, @event.Language) ?? new DefaultAutomaticReply(@event.Id);
            automaticReply.Id = @event.Id;
            automaticReply.Type = (AutomaticReplyType)@event.Type;
            automaticReply.Message = @event.Message;
            automaticReply.Language = @event.Language;
            await _defaultAutomaticReplies.Save(automaticReply);
        }

        public async Task Process(DefaultAutomaticReplyKeyMessageDefined @event)
        {
            var keyMessage = _defaultKeyMessages.GetByTypeLanguageAndHealthRisk((AutomaticReplyKeyMessageType)@event.Type, @event.Language, @event.HealthRiskId) ?? new DefaultAutomaticReplyKeyMessage(@event.Id);
            keyMessage.Id = @event.Id;
            keyMessage.HealthRiskId = @event.HealthRiskId;
            keyMessage.Type = (AutomaticReplyKeyMessageType)@event.Type;
            keyMessage.Message = @event.Message;
            keyMessage.Language = @event.Language;
            await _defaultKeyMessages.Save(keyMessage);
        }

    }
}
