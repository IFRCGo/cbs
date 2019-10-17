using Newtonsoft.Json;
using Nyss.SmsGateway.Logic.Models;

namespace Nyss.Web.Features.SmsGateway
{
    public class SmsDto
    {
        // Required
        [JsonProperty("sender")]
        public string Sender { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("msgid")]
        public string MsgId { get; set; }

        [JsonProperty("apikey")]
        public string ApiKey { get; set; }

        // Optional
        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("text_binary")]
        public byte[] TextBinary { get; set; }

        [JsonProperty("modemno")]
        public int? ModemNo { get; set; }

        [JsonProperty("oididentifier")]
        public string OidIdentifier { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }

    public static class SmsDtoExtensions
    {
        public static Sms ToLogicModel(this SmsDto smsDto)
        {
            if (smsDto == null) return null;

            return new Sms
            {
                Sender = smsDto.Sender,
                Timestamp = smsDto.Timestamp,
                Text = smsDto.Text,
                MsgId = smsDto.MsgId,
                ApiKey = smsDto.ApiKey,
                Timezone = smsDto.Timezone,
                TextBinary = smsDto.TextBinary,
                ModemNo = smsDto.ModemNo,
                OidIdentifier = smsDto.OidIdentifier,
                Latitude = smsDto.Latitude,
                Longitude = smsDto.Longitude
            };
        }
    }
}
