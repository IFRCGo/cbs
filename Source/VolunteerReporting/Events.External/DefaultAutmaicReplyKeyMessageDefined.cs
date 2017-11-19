using doLittle.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events.External
{
    public class DefaultAutmaicReplyKeyMessageDefined : IEvent
    {
        public Guid Id { get; set; }
        public Guid HealthRiskId { get; set; }
        public int Type { get; set; }
        public string Language { get; set; }
        public string Message { get; set; }
    }
}
