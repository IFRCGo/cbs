using System;
using Dolittle.Events;

namespace Events.HealthRisks
{
    public class HealthRiskNameOverridden : IEvent 
    {
        public HealthRiskNameOverridden(string name) => Name = name;

        public string Name { get; }       
    }
}