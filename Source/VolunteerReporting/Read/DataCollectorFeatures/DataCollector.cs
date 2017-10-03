using System;

namespace Read
{
    public class DataCollector
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MobilePhoneNumber { get; set; }

        public DataCollector(Guid id)
        {
            Id = id;
        }
    }
}