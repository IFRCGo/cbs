using System;
using Concepts;

namespace Read.AutomaticReplyMessages
{
    public class DefaultAutomaticReply
    {
        public DefaultAutomaticReply(Guid id) => Id = id;
        public Guid Id { get; set; }
        public AutomaticReplyType Type { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }
    }
}