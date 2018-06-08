using System;
using Concepts;
using Dolittle.ReadModels;

namespace Read.AutomaticReplyMessages
{
    public class DefaultAutomaticReply : IReadModel
    {
        public Guid Id { get; set; }
        public AutomaticReplyType Type { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }

        public DefaultAutomaticReply(Guid id)
        {
            Id = id;
        }
    }
}