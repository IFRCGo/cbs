using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Concepts;

namespace Web.Models
{
    public class DefineAutomaticReplyForProject
    {
        public Guid ProjectId { get; internal set; }
        public AutomaticReplyType Type { get; internal set; }
        public string Language { get; internal set; }
        public string Message { get; internal set; }
    }
}
