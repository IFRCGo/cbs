using Dolittle.Events;

namespace Events.HealthRisks
{
    public class HealthRiskNameSet : IEvent 
    {
        public HealthRiskNameSet(string name) => Name = name;

        public string Name { get; }       
    }
}