using System;
using Read.HealthRiskFeatures;

namespace Read.Tests.Mockups
{
    internal class MockupHealthRiskFeatures : IHealthRisks
    {
        public HealthRisk GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public HealthRisk GetByReadableId(int readableId)
        {
            return new HealthRisk(Guid.NewGuid()) { ReadableId = readableId };
        }

        public void Save(HealthRisk dataCollector)
        {
            throw new NotImplementedException();
        }
    }
}