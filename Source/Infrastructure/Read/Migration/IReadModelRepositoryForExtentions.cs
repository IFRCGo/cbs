using System.Collections.Generic;
using System.Linq;
using Dolittle.ReadModels;

namespace Infrastructure.Read.Migration
{
    public static class IReadModelRepositoryForExtentions
    {
        public static void MigrateAllReadModels<T>(this IReadModelRepositoryFor<T> repo, ICanMigrate<T> migrator)
            where T : IReadModel
        {
            migrator.MigrateAllReadModels();
        }
    }
}