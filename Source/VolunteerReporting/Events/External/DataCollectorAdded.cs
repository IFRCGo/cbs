using System;
using Infrastructure.Events;

namespace Events.External
{
    public class DataCollectorAdded : IEvent
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MobilePhoneNumber { get; set; }
    }
}