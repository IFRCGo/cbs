using Concepts;
using System;
using Dolittle.ReadModels;
using Concepts.HealthRisk;
using Concepts.AutomaticReply;

namespace Read.AutomaticReplyMessages
{
    public class DefaultAutomaticReplyKeyMessage : IReadModel
    {
        public Guid Id { get; set; }
        public HealthRiskId HealthRiskId { get; set; }
        public AutomaticReplyKeyMessageType Type { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }

        public DefaultAutomaticReplyKeyMessage(Guid id)
        {
            Id = id;
        }
    }
}