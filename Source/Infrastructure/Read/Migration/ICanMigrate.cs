using Dolittle.ReadModels;
using System.Collections.Generic;

namespace Infrastructure.Read.Migration
{
    public interface ICanMigrate<T>
        where T : IReadModel
    { 
        /// <summary>
        /// Retrieves the IMigrationStrategies for read model T.
        /// </summary>
        /// <returns></returns>
         IEnumerable<IMigrationStrategyFor<T>> MigrationStrategies { get; }
         /// <summary>
         /// Retrieves the migrated version of readModel after applying all migration strategies on it.
         /// Does not persist changes to the database
         /// </summary>
         /// <param name="readModel"></param>
         /// <returns></returns>
         T GetMigratedReadModel(T readModel);
         /// <summary>
         /// Performs all migrations on readModel and persists the changes to the database collection
         /// </summary>
         /// <param name="ReadModel"></param>
         void MigrateReadModel(T readModel);
         /// <summary>
         /// Performs all migrations on readModels and persists the changes to the database collection
         /// </summary>
         /// <param name="readModels"></param>
         void MigrateReadModels(IEnumerable<T> readModels);
         /// <summary>
         /// Performs all migrations on all readModels and persists the changes to the database collection
         /// </summary>

         void MigrateAllReadModels();

    }
}