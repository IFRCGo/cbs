using doLittle.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events.External
{
    public class ProjectCreated : IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
