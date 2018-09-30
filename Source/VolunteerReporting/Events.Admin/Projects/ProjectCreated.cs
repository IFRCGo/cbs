using Dolittle.Artifacts;
using Dolittle.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events.Admin.Projects
{
    [Artifact("8c120f9a-1f56-43b4-a12a-2bfa5699bc21")]
    public class ProjectCreated : IEvent
    {
        public ProjectCreated(Guid id, string name) 
        {
            this.Id = id;
            this.Name = name;
               
        }
        public Guid Id { get; }
        public string Name { get; }
    }
}
