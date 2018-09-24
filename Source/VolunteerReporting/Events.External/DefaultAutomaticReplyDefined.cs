using Dolittle.Artifacts;
using Dolittle.Events;
using System;

namespace Events.External
{
    public class DefaultAutomaticReplyDefined : IEvent
    {
        public Guid Id { get; set; }
        public int Type { get; set; }
        public string Language { get; set; }
        public string Message { get; set; }
    }
}
