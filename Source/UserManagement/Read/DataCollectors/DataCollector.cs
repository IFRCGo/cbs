using System;
using System.Collections.Generic;
using Concepts;
using Events;

namespace Read
{
    public class DataCollector{
        public Guid Id { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfBirth { get; set; }
        public Sex Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location Location { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public string Email { get; set; }
        public DateTimeOffset RegisteredAt { get; set; }
        //TODO: Should this be nullable before first report is sent? Construct a concept?
        //public DateTimeOffset LastReportRecievedAt { get; set; }
        
        public DataCollector(Guid id) {
            Id = id;
        }       
    }

    public class PhoneNumber
    {
        public PhoneNumber(string value)
        {
            Value = value;
        }
        public string Value { get; set; }
        //TODO: This value should default to false after the MVP and when there is logic for phone number confirmation
        public bool Confirmed { get; set; } = true;

        public override bool Equals(object obj)
        {
            var item = obj as PhoneNumber;

            if (item == null)
            {
                return false;
            }

            return this.Value.Equals(item.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
    
}
