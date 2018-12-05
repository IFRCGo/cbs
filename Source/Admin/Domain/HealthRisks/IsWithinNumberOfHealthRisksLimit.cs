using System;

namespace Domain.HealthRisks
{
    public delegate bool IsWithinNumberOfHealthRisksLimit(Guid projectId); 
}
