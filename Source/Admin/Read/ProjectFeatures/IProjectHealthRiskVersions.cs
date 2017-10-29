using System;
using System.Collections.Generic;
using System.Text;

namespace Read.ProjectFeatures
{
    public interface IProjectHealthRiskVersions
    {
        void Append(Guid projectId, ProjectHealthRisk healthRisk, DateTimeOffset effectiveFromTime);
        IEnumerable<ProjectHealthRiskVersion> GetByProjectIdAndHealthRiskId(Guid projectId, Guid healthRiskId);
    }
}
