using MongoDB.Driver;

namespace Read.Disease
{
    public class HealthRisks : Repository<HealthRisk>, IHealthRisks
    {
        public HealthRisks(IMongoDatabase database) : base(database, "HealthRisk")
        {
        }
    }
}
