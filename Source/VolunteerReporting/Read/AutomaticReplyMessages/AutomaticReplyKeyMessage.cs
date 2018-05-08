
using System;
using Concepts;
using Dolittle.ReadModels;

namespace Read.AutomaticReplyMessages
{
    public class AutomaticReplyKeyMessage : IReadModel, IHaveReadModelIdOf<Guid>
    {
        public Guid Id { get; set; }
        public Guid HealthRiskId { get; set; }
        public Guid ProjectId { get; set; }
        public AutomaticReplyKeyMessageType Type { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }

        public AutomaticReplyKeyMessage(Guid id)
        {
            Id = id;
        } 

    }
}