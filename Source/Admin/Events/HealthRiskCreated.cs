using Infrastructure.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class HealthRiskCreated : IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
