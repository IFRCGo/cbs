using Concepts;
using System;
using Dolittle.ReadModels;

namespace Read.AutomaticReplyMessages
{
    public class DefaultAutomaticReplyKeyMessage : IReadModel
    {
        public Guid Id { get; set; }
        public Guid HealthRiskId { get; set; }
        public AutomaticReplyKeyMessageType Type { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }

        public DefaultAutomaticReplyKeyMessage(Guid id)
        {
            Id = id;
        }
    }
}