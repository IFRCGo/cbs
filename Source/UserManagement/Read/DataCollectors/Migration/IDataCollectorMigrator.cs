using Infrastructure.Read.Migration;

namespace Read.DataCollectors.Migration
{
    public interface IDataCollectorMigrator : ICanMigrate<DataCollector>
    { 
    }
}