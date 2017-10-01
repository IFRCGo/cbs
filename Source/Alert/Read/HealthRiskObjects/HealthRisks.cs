using MongoDB.Driver;

namespace Read.HealthRiskObjects
{
    public class HealthRisks : Repository<HealthRisk>, IHealthRisks
    {
        public HealthRisks(IMongoDatabase database) : base(database, "HealthRisk")
        {
        }
    }
}
