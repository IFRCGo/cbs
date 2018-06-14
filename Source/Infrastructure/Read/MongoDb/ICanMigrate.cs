using Dolittle.ReadModels;
using System.Collections.Generic;

namespace Infrastructure.Read.MongoDb
{
    public interface ICanMigrate<T>
        where T : IReadModel
    {
         T Migrate(T readModel);
         IEnumerable<IMigrationStrategyFor<T>> MigrationStrategies();
         bool NeedMigration(T readModel);
    }
}