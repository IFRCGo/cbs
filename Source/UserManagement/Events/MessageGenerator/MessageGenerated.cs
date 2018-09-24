using System;
using Dolittle.Events;

namespace Events.MessageGenerator
{
    public class MessageGenerated : IEvent
    {
        public MessageGenerated(Guid dataCollectorId, string phoneNumber, string message) 
        {
            this.DataCollectorId = dataCollectorId;
            this.PhoneNumber = phoneNumber;
            this.Message = message;
               
        }
        public Guid DataCollectorId { get; }
        public string PhoneNumber { get; }
        public string Message { get; }

        
    }
}
