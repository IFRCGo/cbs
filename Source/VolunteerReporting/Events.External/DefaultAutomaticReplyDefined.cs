using Dolittle.Events;
using System;
using System.Collections.Generic;
using System.Text;

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
