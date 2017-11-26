using System;

namespace Infrastructure.Events.Web
{
    public class Event
    {
        public string Name { get; set; }
        public Guid EventSourceId { get; set; }
        public dynamic Content { get; set; }
    }
}