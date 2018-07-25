using System.Collections.Generic;
using System.Linq;
using Dolittle.Collections;
using Dolittle.ReadModels;
using Dolittle.Types;
using Infrastructure.Read.Migration;
namespace Read.DataCollectors.Migration
{
    public class DataCollectorMigrator : BaseMigratorFor<DataCollector>,
        IDataCollectorMigrator
    {
        IDataCollectors _repo;

        public DataCollectorMigrator(IInstancesOf<IMigrationStrategyFor<DataCollector>> strategies, IDataCollectors repo)
            : base(strategies)
        {
            _repo = repo;
        }

        public override void MigrateReadModel(DataCollector readModel)
        {
            if (readModel.NeedMigration(MigrationStrategies))
                _repo.Update(GetMigratedReadModel(readModel));
        }

        public override void MigrateAllReadModels()
        {
            var readModels = _repo.Query.Where(_ => true);
            MigrateReadModels(readModels);
        }

    }
}