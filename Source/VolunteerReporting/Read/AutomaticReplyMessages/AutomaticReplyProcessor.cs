using Concepts;
using doLittle.Events.Processing;
using Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.AutomaticReplyMessages
{
    public class AutomaticReplyProcessor : ICanProcessEvents
    {
        private readonly IAutomaticReplies _automaticReplies;
        private readonly IAutomaticReplyKeyMessages _keyMessages;

        public AutomaticReplyProcessor(IAutomaticReplies automaticReplies, IAutomaticReplyKeyMessages keyMessages)
        {
            _automaticReplies = automaticReplies;
            _keyMessages = keyMessages;
        }

        public async Task Process(AutomaticReplyDefined @event)
        {
            var automaticReply = await _automaticReplies.GetByProjectTypeAndLanguageAsync(@event.ProjectId, (AutomaticReplyType)@event.Type, @event.Language) ?? new AutomaticReply(@event.Id);
            automaticReply.ProjectId = @event.ProjectId;
            automaticReply.Type = (AutomaticReplyType)@event.Type;
            automaticReply.Message = @event.Message;
            automaticReply.Language = @event.Language;
            await _automaticReplies.Save(automaticReply);
        }

        public async Task Process(AutomaticReplyRemoved @event)
        {
            await _automaticReplies.Remove(@event.Id);
        }

        public async Task Process(AutomaticReplyKeyMessageDefined @event)
        {
            var keyMessage = await _keyMessages.GetByProjectTypeLanguageAndHealthRiskAsync(@event.ProjectId, (AutomaticReplyKeyMessageType)@event.Type, @event.Language, @event.HealthRiskId) ?? new AutomaticReplyKeyMessage(@event.Id);
            keyMessage.ProjectId = @event.ProjectId;
            keyMessage.HealthRiskId = @event.HealthRiskId;
            keyMessage.Type = (AutomaticReplyKeyMessageType)@event.Type;
            keyMessage.Message = @event.Message;
            keyMessage.Language = @event.Language;
            await _keyMessages.Save(keyMessage);
        }

        public async Task Process(AutomaticReplyKeyMessageRemoved @event)
        {
            await _keyMessages.Remove(@event.Id);
        }
    }
}
