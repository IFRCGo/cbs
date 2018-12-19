/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Concepts.CaseReport;

namespace Read.InvalidCaseReports
{
    public interface IInvalidCaseReportsFromUnknownDataCollectors : IExtendedReadModelRepositoryFor<InvalidCaseReportFromUnknownDataCollector>
    {
        IEnumerable<InvalidCaseReportFromUnknownDataCollector> GetAll();
        IEnumerable<InvalidCaseReportFromUnknownDataCollector> GetByPhoneNumber(string phoneNumber);


        void SaveInvalidReportFromUnknownDataCollector(CaseReportId caseReportId, string message, string origin, IEnumerable<string> errorMessages, DateTimeOffset timestamp);
    }
}
