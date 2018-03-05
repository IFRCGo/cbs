using System;

namespace Web
{
    public class SMSGatewayInfo
    {
        //Sender phone number
        public string GatewayName { get; set; }
        //Timestamp from the SMS Gatewa
        public string GatewayID { get; set; }
        public bool IsDualModem { get; set; }
        public int GatewayMacAddress { get; set; }
        public DateTimeOffset PurchasedDate { get; set; }
    }
}
