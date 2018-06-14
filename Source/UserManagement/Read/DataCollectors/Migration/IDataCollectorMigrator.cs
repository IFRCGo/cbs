using Infrastructure.Read.MongoDb;

namespace Read.DataCollectors.Migration
{
    public interface IDataCollectorMigrator : ICanMigrate<DataCollector>
    {
         
    }
}