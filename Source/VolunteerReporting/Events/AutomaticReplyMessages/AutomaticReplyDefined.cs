using Dolittle.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events.AutomaticReplyMessages
{
    public class AutomaticReplyDefined : IEvent
    {
        public AutomaticReplyDefined(Guid id, Guid projectId, int type, string language, string message) 
        {
            this.Id = id;
            this.ProjectId = projectId;
            this.Type = type;
            this.Language = language;
            this.Message = message;
               
        }
        public Guid Id { get; }
        public Guid ProjectId { get; }
        public int Type { get; }
        public string Language { get; }
        public string Message { get; }
    }
}
