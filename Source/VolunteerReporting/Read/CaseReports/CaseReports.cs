/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using MongoDB.Driver;
using System.Collections.Generic;

namespace Read.CaseReports
{
    public class CaseReports : ExtendedReadModelRepositoryFor<CaseReport>,
        ICaseReports
    {
        public const string CollectionName = "CaseReport";
        
        public CaseReports(IMongoDatabase database)
            : base(database)
        {
        }

        public IEnumerable<CaseReport> GetAll()
        {
            return GetMany(_ => true);
        }
    }
}
