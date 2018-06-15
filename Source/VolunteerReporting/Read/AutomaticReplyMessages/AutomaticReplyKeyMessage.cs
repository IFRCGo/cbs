
using System;
using Concepts.HealthRisk;
using Concepts.Project;
using Concepts.AutomaticReply;
using Dolittle.ReadModels;

namespace Read.AutomaticReplyMessages
{
    public class AutomaticReplyKeyMessage : IReadModel
    {
        public Guid Id { get; set; }
        public HealthRiskId HealthRiskId { get; set; }
        public ProjectId ProjectId { get; set; }
        public AutomaticReplyKeyMessageType Type { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }

        public AutomaticReplyKeyMessage(Guid id)
        {
            Id = id;
        } 
    }
}