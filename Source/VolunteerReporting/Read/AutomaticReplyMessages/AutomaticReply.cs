using Concepts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Read.AutomaticReplyMessages
{
    public class AutomaticReply
    {
        public AutomaticReply(Guid id) => Id = id;
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public AutomaticReplyType Type { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }
    }
}
