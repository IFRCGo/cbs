using Concepts;
using doLittle.Domain;
using doLittle.Runtime.Events;
using Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class AutomaticReplyDefinition : AggregateRoot
    {
        public AutomaticReplyDefinition(EventSourceId eventSourceId) : base(eventSourceId)
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
