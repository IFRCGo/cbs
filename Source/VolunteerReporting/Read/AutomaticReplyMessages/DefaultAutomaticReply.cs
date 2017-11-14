using System;
using Events.External;

namespace Read.AutomaticReplyMessages
{
    public class DefaultAutomaticReply
    {
        public DefaultAutomaticReply(Guid id) => Id = id;
        public Guid Id { get; set; }
        public DefaultAutomaticReplyType Type { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }
    }
}