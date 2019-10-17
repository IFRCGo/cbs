using System;
using System.Globalization;
using System.Threading;


namespace Nyss.SmsGateway.Logic.Models
{
    public class Sms
    {
        private const string TimestampFormat = "yyyyMMddHHmmss";

        // Required
        public string Sender { get; set; }
        public string Timestamp { get; set; }

        public DateTime TimestampDateTime =>
            DateTime.ParseExact(Timestamp, TimestampFormat, Thread.CurrentThread.CurrentCulture);

        public string Text { get; set; }
        public string MsgId { get; set; }
        public string ApiKey { get; set; }

        // Optional
        public string Timezone { get; set; }
        public byte[] TextBinary { get; set; }
        public int? ModemNo { get; set; }
        public string OidIdentifier { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        
        public ValidationResult Validate()
        {
            var result = new ValidationResult();
            
            if(string.IsNullOrWhiteSpace(Sender))
                result.Errors.Add("Sender is required.");

            if (string.IsNullOrWhiteSpace(Timestamp))
                result.Errors.Add("Timestamp is required.");

            if(!DateTime.TryParseExact(Timestamp, TimestampFormat, Thread.CurrentThread.CurrentCulture, DateTimeStyles.None, out var dump))
                result.Errors.Add($"Timestamp must be in format {TimestampFormat}.");

            if(string.IsNullOrWhiteSpace(Text))
                result.Errors.Add("Text is required.");
            if(string.IsNullOrWhiteSpace(MsgId))
                result.Errors.Add("Message ID is required.");
            if(string.IsNullOrWhiteSpace(ApiKey))
                result.Errors.Add("ApiKey is required.");

            return result;
        }
    }
}