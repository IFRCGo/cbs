using Dolittle.Events;
using System;

namespace Events.External
{
    public class DefaultAutomaticReplyKeyMessageDefined : IEvent
    {
        public Guid Id { get; set; }
        public Guid HealthRiskId { get; set; }
        public int Type { get; set; }
        public string Language { get; set; }
        public string Message { get; set; }
    }
}
