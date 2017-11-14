using Events.External;

namespace Read.AutomaticReplyMessages
{
    public interface IDefaultAutomaticReplies
    {
        DefaultAutomaticReply GetByTypeAndLanguage(DefaultAutomaticReplyType type, string language);
        void Save(DefaultAutomaticReply automaticReply);
    }
}