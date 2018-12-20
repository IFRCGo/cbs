using System;

namespace Domain.HealthRisks
{
    public delegate bool IsWithinNumberOfHealthRisksLimit(Guid projectId);
    public delegate bool IsHealthRiskUniqueWithinProject(Guid healthRiskId, Guid projectId);
    public delegate bool IsHealthRiskExisting(Guid healthRiskId);

}
