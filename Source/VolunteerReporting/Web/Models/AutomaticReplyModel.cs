using Events.External;

namespace Web.Controllers
{
    public class AutomaticReplyModel
    {
        public bool Auto { get; set; }
        public DefaultAutomaticReplyType Type { get; set; }
        public string Language { get; set; }
        public string Message { get; set; } 
    }
}