/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;

namespace Read.CaseReports
{
    public interface ICaseReportsFromUnknownDataCollectors : IExtendedReadModelRepositoryFor<CaseReportFromUnknownDataCollector>
    {
        IEnumerable<CaseReportFromUnknownDataCollector> GetAll();

        IEnumerable<CaseReportFromUnknownDataCollector> GetByPhoneNumber(string phoneNumber);
    }
}
