using System;
using System.Collections.Generic;
using Concepts;

namespace Domain.DataCollector.Update
{
    public class UpdateDataCollector
    {
        public Guid DataCollectorId { get; set; }

        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location GpsLocation { get; set; }
        public IEnumerable<string> PhoneNumbersAdded { get; set; }
        public IEnumerable<string> PhoneNumbersRemoved { get; set; }
     
    }
}
