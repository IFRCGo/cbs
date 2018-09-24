using Dolittle.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events.AutomaticReplyMessages
{
    public class AutomaticReplyKeyMessageDefined : IEvent
    {
        
        public AutomaticReplyKeyMessageDefined(Guid id, Guid projectId, Guid healthRiskId, int type, string language, string message) 
        {
            this.Id = id;
            this.ProjectId = projectId;
            this.HealthRiskId = healthRiskId;
            this.Type = type;
            this.Language = language;
            this.Message = message;
               
        }
        public Guid Id { get;}
        public Guid ProjectId { get; }
        public Guid HealthRiskId { get; }
        public int Type { get; }
        public string Language { get; }
        public string Message { get; }
    }
}
