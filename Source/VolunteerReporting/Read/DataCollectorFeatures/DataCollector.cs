using System;

namespace Read
{
    public class DataCollector
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //TODO: Should a datacollector have more than one phone number?
        public string MobilePhoneNumber { get; set; }

        public DataCollector(Guid id)
        {
            Id = id;
        }
    }
}