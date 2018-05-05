using System;
using Concepts;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events;

namespace Domain
{
    public class AutomaticReplyDefinition : AggregateRoot
    {
        public AutomaticReplyDefinition(EventSourceId eventSourceId): base(eventSourceId)
        {

        }

        public void Define(Guid projectId, AutomaticReplyType type, string language, string message)
        {
            Apply(new AutomaticReplyDefined()
            {
                Id = Guid.NewGuid(),
                    ProjectId = projectId,
                    Type = (int)type,
                    Language = language,
                    Message = message
            });
        }

        public void DefineKeyMessage(Guid projectId, Guid healthRiskId, AutomaticReplyKeyMessageType type, string language, string message)
        {
            Apply(new AutomaticReplyKeyMessageDefined()
            {
                Id = Guid.NewGuid(),
                    HealthRiskId = healthRiskId,
                    ProjectId = projectId,
                    Type = (int)type,
                    Language = language,
                    Message = message
            });
        }
    }
}