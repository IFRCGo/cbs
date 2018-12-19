/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using MongoDB.Driver;
using System.Collections.Generic;

namespace Read.CaseReports
{
    public class CaseReportsFromUnknownDataCollectors : ExtendedReadModelRepositoryFor<CaseReportFromUnknownDataCollector>,
        ICaseReportsFromUnknownDataCollectors
    {
        public CaseReportsFromUnknownDataCollectors(IMongoDatabase database)
            : base(database)
        {
        }
        public IEnumerable<CaseReportFromUnknownDataCollector> GetAll()
        {
            return GetMany(_ => true);
        }

        public IEnumerable<CaseReportFromUnknownDataCollector> GetByPhoneNumber(string phoneNumber)
        {
            return GetMany(r => r.Origin == phoneNumber);
        }
    }
}
