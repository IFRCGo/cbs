
using System;
using Concepts;

namespace Read.AutomaticReplyMessages
{
    public class AutomaticReplyKeyMessage
    {
        public AutomaticReplyKeyMessage(Guid id) => Id = id;
        public Guid Id { get; set; }
        public Guid HealthRiskId { get; set; }
        public Guid ProjectId { get; set; }
        public AutomaticReplyKeyMessageType Type { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }

    }
}