using Infrastructure.Read.MongoDb;

namespace Read.DataCollectors.Migration
{
    public class RemoveNationalSociety : IMigrationStrategyFor<DataCollector>
    {
        public DataCollector ApplyMigrationStrategy(DataCollector readModel)
        {
            readModel.ExtraElements.Remove("NationalSociety");
            return readModel;
        }

        public bool NeedsMigration(DataCollector readModel)
        {
            if (readModel.ExtraElements == null) return false;
            return readModel.ExtraElements.ContainsKey("NationalSociety");
        }
    }
}