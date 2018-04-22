namespace Web
{
    public class SMS
    {
        public string Sender {  get; set; } //Equivalent of SMSSync: "From"
        public string Timestamp {  get; set; } //Equivalent of SMSSync: "Sent_timestamp"
        public string MsgID {  get; set; }  //Equivalent of SMSSync: "Message_id"

        public string OID { get; set; }  //Equivalent of SMSSync: "Secret"
        public string ModemNo {  get; set; }  //Equivalent of SMSSync: "device_id"
        public string Text {  get; set; } //Equivalent of SMSSync: "Message"
    }

        public class SMSSync
    {
        public string From {  get; set; }
        public string Message {  get; set; }
        public string Message_id {  get; set; }
        public string Sent_to  { get; set; }
        public string Secret { get; set;}

        public string device_id{get; set;}
        public string Sent_timestamp  {  get; set; } 

    }
}