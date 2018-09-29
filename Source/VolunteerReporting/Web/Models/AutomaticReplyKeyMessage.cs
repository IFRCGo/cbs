using Concepts;
using Concepts.AutomaticReply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class AutomaticReplyKeyMessage
    {
        public Guid HealthRiskId { get; set; }
        public bool IsDefault { get; set; }
        public AutomaticReplyKeyMessageType Type { get; set; }
        public string Language { get; set; }
        public string Message { get; set; }
    }
}
