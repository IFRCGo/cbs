using System;
using System.Collections.Generic;
using Concepts;
using Events;


namespace Read.DataCollectors
{
    public class DataCollector
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public int YearOfBirth { get; set; }
        public Sex Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location Location { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public DateTimeOffset RegisteredAt { get; set; }

        //TODO: Should this be nullable before first report is sent? Construct a concept?
        //TKV (10.02.2018): I think thi should be null untill first report is send so that
        //it chould be shown in the frontend that we have not recived any report.
        public DateTimeOffset? LastReportRecievedAt { get; set; }

        public DataCollector(Guid id)
        {
            Id = id;
        }
    }

}
