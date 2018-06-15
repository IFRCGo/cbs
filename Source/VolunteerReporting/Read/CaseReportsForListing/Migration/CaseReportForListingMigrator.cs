using System.Collections.Generic;
using System.Linq;
using Dolittle.ReadModels;
using Dolittle.Types;
using Infrastructure.Read.Migration;

namespace Read.CaseReportsForListing.Migration
{
    public class CaseReportForListingMigrator : BaseMigratorFor<CaseReportForListing>,
        ICaseReportForListingMigrator
    {
        readonly ICaseReportsForListing _repo;

        public CaseReportForListingMigrator(IInstancesOf<IMigrationStrategyFor<CaseReportForListing>> strategies,
            ICaseReportsForListing repo) 
            : base(strategies)
        {
            _repo = repo;
        }

        public override void MigrateAllReadModels()
        {
            var readModels = _repo.Query.Where(_ => true).AsEnumerable();
            
            MigrateReadModels(readModels);
        }

        public override void MigrateReadModel(CaseReportForListing readModel)
        {
            if (readModel.NeedMigration(MigrationStrategies))
                _repo.Update(GetMigratedReadModel(readModel));
        }
    }
}