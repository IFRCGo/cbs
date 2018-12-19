/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Types;

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