using System.Collections.Generic;
using Dolittle.Collections;
using Dolittle.ReadModels;
using Dolittle.Types;
using Infrastructure.Read.Migration;
namespace Read.DataCollectors.Migration
{
    public class DataCollectorMigrator : IDataCollectorMigrator
    {
        IInstancesOf<IMigrationStrategyFor<DataCollector>> _strategies;
        IDataCollectors _repo;
        public DataCollectorMigrator(IInstancesOf<IMigrationStrategyFor<DataCollector>> strategies, IDataCollectors repo)
        {
            _strategies = strategies;
            _repo = repo;
        }

        public IEnumerable<IMigrationStrategyFor<DataCollector>> MigrationStrategies() => _strategies;

        public DataCollector MigrateReadmodel(DataCollector readModel)
        {
            var migrated = false;
            foreach (var strategy in MigrationStrategies())
            {
                if(strategy.CanMigrate(readModel)) 
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
                if (strategy.CanMigrate(readModel))
                    return true;
            }
            return false;
        }
    }
}