using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.External
{
    [Artifact("8ba78d0d-1944-463e-bcad-11a037adf743")]
    public class HealthRiskModified : IEvent
    {
        public HealthRiskModified(Guid id, string name, int readableId) 
        {
            this.Id = id;
            this.Name = name;
            this.ReadableId = readableId;
               
        }
        public Guid Id { get; }
        public string Name { get; }
        public int ReadableId { get; }
    }
}