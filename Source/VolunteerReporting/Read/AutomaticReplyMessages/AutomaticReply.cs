using System;
using Concepts;
using Dolittle.ReadModels;

namespace Read.AutomaticReplyMessages
{
    public class AutomaticReply : IReadModel, IHaveReadModelIdOf<Guid>
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public AutomaticReplyType Type { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }

        public AutomaticReply(Guid id)
        {
            Id = id;
        }
    }
}