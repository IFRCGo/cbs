using System;
using Dolittle.Commands;

namespace Domain.HealthRisk
{
    public class CreateHealthRisk : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ReadableId { get; set; }
        public string CaseDefinition { get; set; }
        //public string ConfirmedCase { get; set; }
        public string Note { get; set; }
        //public string SuspectedCase { get; set; }
        //public string ProbableCase { get; set; }
        public string CommunityCase { get; set; }
        public string KeyMessage { get; set; }
    }
}
