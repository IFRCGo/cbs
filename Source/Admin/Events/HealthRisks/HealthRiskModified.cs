using System;
using Dolittle.Events;

namespace Events.HealthRisks
{
    public class HealthRiskModified : IEvent 
    {
        
        public HealthRiskModified (Guid id, string name, int readableId, string caseDefinition, string note, string communityCase, string keyMessage) 
        {
            this.Id = id;
            this.Name = name;
            this.ReadableId = readableId;
            this.CaseDefinition = caseDefinition;
            this.Note = note;
            this.CommunityCase = communityCase;
            this.KeyMessage = keyMessage;

        }
        public Guid Id { get; }
        public string Name { get; }
        public int ReadableId { get; }
        public string CaseDefinition { get; }
        //public string ConfirmedCase { get; }
        public string Note { get; }
        //public string SuspectedCase { get; }
        //public string ProbableCase { get; }
        public string CommunityCase { get; }
        public string KeyMessage { get; }

    }
}