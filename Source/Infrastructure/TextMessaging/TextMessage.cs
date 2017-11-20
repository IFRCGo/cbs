using System;

namespace Infrastructure.TextMessaging
{
    public class TextMessage
    {
        public Guid Id { get; set; }
        public DateTimeOffset Sent { get; set; }
        public string OriginNumber { get; set; }
        public string Message { get; set; }
        public string Keyword { get; set; }
        public string FullMessage { get; set; }
        public string ReceivedAtGatewayNumber { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}