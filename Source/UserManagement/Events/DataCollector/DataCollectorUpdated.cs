using System;
using Concepts;
using doLittle.Events;

namespace Events.DataCollector
{
    public class DataCollectorUpdated : IEvent
    {
        public Guid DataCollectorId { get; set; }

        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public int YearOfBirth { get; set; }
        public int Sex { get; set; } //Do we need Transgender / Other?
        public Guid NationalSociety { get; set; }
        public int PreferredLanguage { get; set; }
        public double LocationLongitude { get; set; }
        public double LocationLatitude { get; set; }
        public string Email { get; set; }
    }
}