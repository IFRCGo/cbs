using System;
using Dolittle.Events;

namespace Events.DataCollector
{
    public class DataCollectorPreferredLanguageChanged : IEvent
    {
        public Guid DataCollectorId { get; set; }
        public int Language { get; set; }

        public DataCollectorPreferredLanguageChanged(Guid dataCollectorId, int language)
        {
            DataCollectorId = dataCollectorId;
            Language = language;
        }
    }
}