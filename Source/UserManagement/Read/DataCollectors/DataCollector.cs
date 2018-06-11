using System;
using System.Collections.Generic;
using Concepts;
using Dolittle.ReadModels;


namespace Read.DataCollectors
{
    public class DataCollector : IReadModel
    { 
        public DataCollectorId Id { get; set; }

        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public int YearOfBirth { get; set; }
        public Sex Sex { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location Location { get; set; }

        public string District { get; set; }
        public string Region { get; set; }
        public string Village { get; set; }

        public List<PhoneNumber> PhoneNumbers { get; set; }
        public DateTimeOffset RegisteredAt { get; set; }

        public DateTimeOffset? LastReportRecievedAt { get; set; }

        public DataCollector(Guid id)
        {
            Id = id;
        }
    }
}
