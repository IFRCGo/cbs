using System.Collections.Generic;
using Dolittle.ReadModels;
using Dolittle.Types;
using Infrastructure.Read.MongoDb;

namespace Read.CaseReportsForListing.Migration
{
    public class CaseReportForListingMigrator : ICaseReportForListingMigrator
    {
        readonly IInstancesOf<IMigrationStrategyFor<CaseReportForListing>> _strategies; 
        readonly ICaseReportsForListing _repo;

        public CaseReportForListingMigrator(IInstancesOf<IMigrationStrategyFor<CaseReportForListing>> strategies,
            ICaseReportsForListing repo) 
        {
            _strategies = strategies;
            _repo = repo;
        }        
            
        public CaseReportForListing Migrate(CaseReportForListing readModel)
        {
            var migrated = false;

            foreach (var strategy in MigrationStrategies())
            {
                if (strategy.NeedsMigration(readModel))
                {
                    readModel = strategy.ApplyMigrationStrategy(readModel);
                    migrated = true;
                }
            }

            if (migrated)
                _repo.Update(readModel);
            
            return readModel;
        }

        public IEnumerable<IMigrationStrategyFor<CaseReportForListing>> MigrationStrategies() => _strategies;

        public bool NeedMigration(CaseReportForListing readModel)
        {
            foreach (var strategy in MigrationStrategies())
            {
                if (strategy.NeedsMigration(readModel))
                    return true;
            }
            return false;
        }
    }
}