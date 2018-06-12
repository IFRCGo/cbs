using Concepts;
using Dolittle.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class DefineAutomaticReplyForProject : ICommand
    {
        public ProjectId ProjectId { get; set; }
        public AutomaticReplyType Type { get; set; }
        public string Language { get; set; }
        public string Message { get; set; }
    }
}
