using Concepts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class DefineAutomaticReplyKeyMessageForProject
    {
        public Guid HealthRiskId { get; set; }
        public Guid ProjectId { get; set; }
        public AutomaticReplyKeyMessageType Type { get; set; }
        public string Language { get; set; }
        public string Message { get; set; }
    }
}
