using Dolittle.Artifacts;
using Dolittle.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events.External
{
    [Artifact("753c49a2-8b97-4823-8e76-c5fe80a432db")]
    public class ProjectUpdated : IEvent
    {
        public ProjectUpdated(Guid id, string name) 
        {
            this.Id = id;
            this.Name = name;
               
        }
        public Guid Id { get; }
        public string Name { get; }
    }
}
