using System.Collections.Generic;
using Dolittle.ReadModels;
using Infrastructure.Read.MongoDb;

namespace Infrastructure.Read.Migration
{
    public interface IMigrationStrategyFor<T>
        where T : IReadModel
    {
        bool CanMigrate(T readModel);
        T ApplyMigrationStrategy(T readModel);
    }
}