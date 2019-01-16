using System;
using Dolittle.Events;

namespace Events.Management.HealthRisks
{
    public class HealthRiskRegistered : IEvent
    {
        public HealthRiskRegistered(Guid healthRiskId, int readableId, string name) 
        {
            HealthRiskId = healthRiskId;
            ReadableId = readableId;
            Name = name;
               
        }
        public Guid HealthRiskId {get;}
        public int ReadableId {get;}  
        public string Name {get;}


    }
}
