namespace Read.HealthRisks
{
    public class HealthRisksEventHandler : IHealthRisksEventHandler
    {
        private readonly MongoDBHandler _dbHandler;

        public HealthRisksEventHandler(MongoDBHandler dbHandler)
        {
            _dbHandler = dbHandler;
        }

        public void Handle(HealthRisk healthRisk)
        {
            _dbHandler.Insert(healthRisk);
        }
    }
}