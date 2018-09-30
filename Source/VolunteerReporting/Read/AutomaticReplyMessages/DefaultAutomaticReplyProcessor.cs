using Dolittle.Events.Processing;
using Events.Admin.DefaultReplyMessages;

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
        [EventProcessor("9e039492-a02f-4ffd-b99c-e745618f3f80")]
        public void Process(DefaultAutomaticReplyDefined @event)
        {
            _defaultAutomaticReplies.SaveDefaultAutomaticReply(
                @event.Id,
                @event.Type,
                @event.Language,
                @event.Message);
            
        }
        [EventProcessor("5c591794-d3ac-4190-bbbc-d7f7445a8967")]
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
