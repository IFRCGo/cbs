using Dolittle.Events.Processing;
using Events.External;

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

        public void Process(DefaultAutomaticReplyDefined @event)
        {
            _defaultAutomaticReplies.SaveDefaultAutomaticReply(
                @event.Id,
                @event.Type,
                @event.Language,
                @event.Message);
            
        }

        public void Process(DefaultAutomaticReplyKeyMessageDefined @event)
        {
            _defaultKeyMessages.SaveDefaultAutomaticReplyKeyMessage(
                @event.Id,
                @event.Type,
                @event.Language,
                @event.Message,
                @event.HealthRiskId);
            
        }

    }
}
