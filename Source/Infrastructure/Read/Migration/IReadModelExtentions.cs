using System.Collections.Generic;
using Dolittle.ReadModels;

namespace Infrastructure.Read.Migration
{
    public static class IReadModelExtentions
    {
        public static bool NeedMigration<T>(this T readModel, IMigrationStrategyFor<T> migrationStrategy) 
            where T : IReadModel
        {
            return migrationStrategy.CanMigrate(readModel);
        }
        public static bool NeedMigration<T>(this T readModel, IEnumerable<IMigrationStrategyFor<T>> migrationStrategies)
            where T : IReadModel 
        {
            foreach (var strategy in migrationStrategies)
            {
                if (readModel.NeedMigration(strategy))
                    return true;            
            }
            return false;
        }
    }
}