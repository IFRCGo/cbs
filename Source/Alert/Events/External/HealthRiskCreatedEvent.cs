using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Events;

namespace Events.External
{
    public class HealthRiskCreatedEvent : IEvent 
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
