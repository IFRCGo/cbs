using System;
using Dolittle.Events;

namespace Events.DataCollector
{
    public class DataCollectorPreferredLanguageChanged : IEvent
    {
        public Guid DataCollectorId { get; }
        public int Language { get; }

        public DataCollectorPreferredLanguageChanged(Guid dataCollectorId, int language)
        {
            DataCollectorId = dataCollectorId;
            Language = language;
        }
    }
}