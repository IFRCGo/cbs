using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.HealthRisks
{
    public delegate bool IsHealthRiskUniqueWithinProject(Guid healthRiskId, Guid projectId);
}
