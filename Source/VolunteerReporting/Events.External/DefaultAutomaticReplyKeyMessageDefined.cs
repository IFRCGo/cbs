// CANNOT FIND THIS EVENT IN ANY BOUNDED CONTEXT
using Dolittle.Events;
using System;

namespace Events.External
{
    public class DefaultAutomaticReplyKeyMessageDefined : IEvent
    {

        public DefaultAutomaticReplyKeyMessageDefined(Guid id, Guid healthRiskId, int type, string language, string message) 
        {
            this.Id = id;
            this.HealthRiskId = healthRiskId;
            this.Type = type;
            this.Language = language;
            this.Message = message;
               
        }
        public Guid Id { get; } 
        public Guid HealthRiskId { get; }
        public int Type { get; }
        public string Language { get; }
        public string Message { get; }
    }
}
