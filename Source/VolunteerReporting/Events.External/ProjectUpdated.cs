using doLittle.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events.External
{
    public class ProjectUpdated : IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
