using System;
using Infrastructure.Events;

namespace Events.External
{
    public class DataCollectorRegistered : IEvent
    {    
        public Guid Id { get; set; }
    }
}