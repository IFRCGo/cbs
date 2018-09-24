using System;
using Dolittle.Events;

namespace Events.HealthRisk {
    public class HealthRiskModified : IEvent {
        
        public HealthRiskModified (Guid id, string name, int readableId, string caseDefinition, string confirmedCase, string note, string suspectedCase, string probableCase, string communityCase, string keyMessage) {
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
        //public string ConfirmedCase { get; set; }
        public string Note { get; }
        //public string SuspectedCase { get; set; }
        //public string ProbableCase { get; set; }
        public string CommunityCase { get; }
        public string KeyMessage { get; }

    }
}