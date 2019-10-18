using System;
using System.Globalization;
using System.Threading;
using NetTopologySuite.Geometries;

namespace Nyss.Web.Features.SmsGateway.Logic.Models
{
    public class Sms
    {
        private const string TimestampFormat = "yyyyMMddHHmmss";

        // Required
        public string Sender { get; set; }
        public string Timestamp { get; set; }

        internal DateTime ReceivedAt =>
            DateTime.ParseExact(Timestamp, TimestampFormat, Thread.CurrentThread.CurrentCulture);

        public string Text { get; set; }
        public string MsgId { get; set; }
        public string ApiKey { get; set; }

        // Optional
        public string Timezone { get; set; }
        public byte[] TextBinary { get; set; }
        public int? ModemNo { get; set; }
        public string OidIdentifier { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        internal Coordinate Coordinate => new Coordinate(Latitude, Longitude);
        internal Point Location => Geometry.DefaultFactory.CreatePoint(Coordinate);

        public SmsProcessResult Validate()
        {
            var result = new SmsProcessResult();
            
            if(string.IsNullOrWhiteSpace(Sender))
                result.RequestErrors.Add("Sender is required.");

            if (string.IsNullOrWhiteSpace(Timestamp))
                result.RequestErrors.Add("Timestamp is required.");

            if(!DateTime.TryParseExact(Timestamp, TimestampFormat, Thread.CurrentThread.CurrentCulture, DateTimeStyles.None, out var dump))
                result.RequestErrors.Add($"Timestamp must be in format {TimestampFormat}.");

            if(string.IsNullOrWhiteSpace(Text))
                result.RequestErrors.Add("Text is required.");
            if(string.IsNullOrWhiteSpace(MsgId))
                result.RequestErrors.Add("Message ID is required.");
            if(string.IsNullOrWhiteSpace(ApiKey))
                result.RequestErrors.Add("ApiKey is required.");

            return result;
        }
    }
}