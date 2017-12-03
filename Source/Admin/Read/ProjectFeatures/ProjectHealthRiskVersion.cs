using System;

namespace Read.ProjectFeatures
{
    public class ProjectHealthRiskVersion
    {
        public Guid Id { get; set; }    // Do we really need this?
        public Guid ProjectId { get; set; }
        public ProjectHealthRisk HealthRisk { get; set; }
        public DateTimeOffset EffectiveFromTime { get; set; } 
    }
}