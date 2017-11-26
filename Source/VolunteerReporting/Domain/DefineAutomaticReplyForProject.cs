using Concepts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class DefineAutomaticReplyForProject
    {
        public Guid ProjectId { get; set; }
        public AutomaticReplyType Type { get; set; }
        public string Language { get; set; }
        public string Message { get; set; }
    }
}
