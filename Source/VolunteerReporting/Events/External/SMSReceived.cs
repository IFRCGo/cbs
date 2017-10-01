using Infrastructure.Events;
using System;

namespace Events.External
{
    public class SMSReceived : IEvent
    {
        public Guid Id { get; set; }
        public DateTime Sent { get; set; }

        /// <summary>
        /// Phone number of sender
        /// </summary>
        public string PhoneNumber { get; set; }  //Long? PhoneNumber custom type?

        public string Message { get; set; }

        //TODO: verify content with Kristian
    }
}
