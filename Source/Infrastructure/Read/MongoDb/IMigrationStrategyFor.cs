using System.Collections.Generic;
using Dolittle.ReadModels;
using Infrastructure.Read.MongoDb;

namespace Infrastructure.Read.MongoDb
{
    public interface IMigrationStrategyFor<T>
        where T : IReadModel
    {
        bool NeedsMigration(T readModel);
        T ApplyMigrationStrategy(T readModel);
    }
}