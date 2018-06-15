using System.Collections.Generic;
using Dolittle.ReadModels;
using Dolittle.Types;

namespace Infrastructure.Read.Migration
{
    public abstract class BaseMigratorFor<T> : ICanMigrate<T>
        where T : IReadModel
    {
        public IEnumerable<IMigrationStrategyFor<T>> MigrationStrategies {get; }
        public BaseMigratorFor(IInstancesOf<IMigrationStrategyFor<T>> strategies)
        {
            MigrationStrategies = strategies;
        }

        public T GetMigratedReadModel(T readModel)
        {
            foreach (var strategy in MigrationStrategies)
            {
                if(strategy.CanMigrate(readModel)) 
                {
                    readModel = strategy.ApplyMigrationStrategy(readModel);
                }
            }
            return readModel;
        }

        public void MigrateReadModels(IEnumerable<T> readModels)
        {
            foreach (var readModel in readModels)
            {
                MigrateReadModel(readModel);
            }
        }
        public abstract void MigrateAllReadModels();

        public abstract void MigrateReadModel(T readModel);

    }
}