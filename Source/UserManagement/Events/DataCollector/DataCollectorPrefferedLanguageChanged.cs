using System;
using Dolittle.Events;

namespace Events.DataCollector
{
    public class DataCollectorPrefferedLanguageChanged : IEvent
    {
        public Guid DataCollectorId { get; set; }
        public int Language { get; set; }

        public DataCollectorPrefferedLanguageChanged(Guid dataCollectorId, int language)
        {
            DataCollectorId = dataCollectorId;
            Language = language;
        }
    }
}