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
        public int YearOfBirth { get; set; }
        public Sex Sex { get; set; } //Do we need Transgender / Other?
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location GpsLocation { get; set; }
        public List<string> MobilePhoneNumbersAdded { get; set; }
        public List<string> MobilePhoneNumbersRemoved { get; set; }
        public string Email { get; set; }
    }
}
