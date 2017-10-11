using System;
using System.Collections.Generic;

namespace Read
{
    public class DataCollector
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> MobilePhoneNumbers { get; set; }
        public string LocationLongitude { get; set; }
        public string LocationLatitude { get; set; }

        public DataCollector(Guid id)
        {
            Id = id;
        }
    }
}