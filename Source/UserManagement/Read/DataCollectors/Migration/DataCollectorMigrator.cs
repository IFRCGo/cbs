using System.Collections.Generic;
using Dolittle.Collections;
using Dolittle.ReadModels;
using Dolittle.Types;
using Infrastructure.Read.MongoDb;
namespace Read.DataCollectors.Migration
{
    public class DataCollectorMigrator : IDataCollectorMigrator
    {
        IInstancesOf<IMigrationStrategyFor<DataCollector>> _strategies;
        IReadModelRepositoryFor<DataCollector> _repo;
        public DataCollectorMigrator(IInstancesOf<IMigrationStrategyFor<DataCollector>> strategies, IReadModelRepositoryFor<DataCollector> repo)
        {
            _strategies = strategies;
            _repo = repo;
        }

        public IEnumerable<IMigrationStrategyFor<DataCollector>> MigrationStrategies() => _strategies;

        public DataCollector Migrate(DataCollector readModel)
        {
            var migrated = false;
            foreach (var strategy in MigrationStrategies())
            {
                if(strategy.NeedsMigration(readModel)) 
                {
                    readModel = strategy.ApplyMigrationStrategy(readModel);
                    migrated = true;
                }
            }
            if (migrated)
                _repo.Update(readModel);
            return readModel;
        }

        public bool NeedMigration(DataCollector readModel)
        {
            foreach (var strategy in MigrationStrategies())
            {
                if (strategy.NeedsMigration(readModel))
                    return true;
            }
            return false;
        }
    }
}