using System;
using Concepts.Project;
using Concepts.HealthRisk;
using Concepts.AutomaticReply;
using Dolittle.Commands;

namespace Domain.AutomaticReplyMessages
{
    public class DefineAutomaticReplyKeyMessageForProject : ICommand
    {
        public HealthRiskId HealthRiskId { get; set; }
        public ProjectId ProjectId { get; set; }
        public AutomaticReplyKeyMessageType Type { get; set; }
        public string Language { get; set; }
        public string Message { get; set; }
    }
}