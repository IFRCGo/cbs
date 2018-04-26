using System;
using Concepts;
using Dolittle.Commands;

namespace Domain
{
    public class DefineAutomaticReplyKeyMessageForProject : ICommand
    {
        public Guid HealthRiskId { get; set; }
        public Guid ProjectId { get; set; }
        public AutomaticReplyKeyMessageType Type { get; set; }
        public string Language { get; set; }
        public string Message { get; set; }
    }
}