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
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location Location { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public string Email { get; set; }
        
        public DataCollector(Guid id) {
            Id = id;
        }       
    }

    
}
