using Infrastructure.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class HealthRiskCreated : IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ReadableId { get; set; }
        public int? Threshold { get; set; }
        public string ConfirmedCase { get; set; }
        public string Note { get; set; }
        public string SuspectedCase { get; set; }
        public string ProbableCase { get; set; }
        public string CommunityCase { get; set; }
    }
}
