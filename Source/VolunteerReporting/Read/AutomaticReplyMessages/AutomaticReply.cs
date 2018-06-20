using System;
using Concepts;
using Dolittle.ReadModels;
using Concepts.Project;
using Concepts.AutomaticReply;

namespace Read.AutomaticReplyMessages
{
    public class AutomaticReply : IReadModel
    {
        public Guid Id { get; set; }
        public ProjectId ProjectId { get; set; }
        public AutomaticReplyType Type { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }

        public AutomaticReply(Guid id)
        {
            Id = id;
        }
    }
}