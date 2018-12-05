using System;

namespace Domain.HealthRisks
{
    public delegate bool IsHealthRiskUniqueWithinProject(Guid healthRiskId, Guid projectId);
}
