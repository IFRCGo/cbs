using System;

namespace Infrastructure.TextMessaging
{
    public class OutgoingTextMessage
    {
        /// <summary>
        /// Id, for tracking
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// Full number, with country code
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// The location of the receiver. This will select the most optimal gateway.
        /// </summary>
        public string ReceiverCountryCode { get; set; }

        /// <summary>
        /// Actual message content
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// How long the Gateway should try before the message is concidered as not sent. 
        /// </summary>
        public int TimeToLiveInMinutes { get; set; }
    }
}