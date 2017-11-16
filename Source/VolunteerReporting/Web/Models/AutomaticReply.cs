using Concepts;

namespace Web.Controllers.Models
{
    public class AutomaticReply
    {
        public bool IsDefault { get; set; }
        public AutomaticReplyType Type { get; set; }
        public string Language { get; set; }
        public string Message { get; set; } 
    }
}