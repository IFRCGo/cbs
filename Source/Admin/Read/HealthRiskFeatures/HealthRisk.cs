using System;
using System.Collections.Generic;
using System.Text;

namespace Read.HealthRiskFeatures
{
    public class HealthRisk
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
        public string KeyMessage { get; internal set; }
    }
}
