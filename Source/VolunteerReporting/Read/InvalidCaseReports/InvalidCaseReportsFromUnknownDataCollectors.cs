/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Concepts.CaseReport;

namespace Read.InvalidCaseReports
{
    public class InvalidCaseReportsFromUnknownDataCollectors : ExtendedReadModelRepositoryFor<InvalidCaseReportFromUnknownDataCollector>,
        IInvalidCaseReportsFromUnknownDataCollectors
    {
        public InvalidCaseReportsFromUnknownDataCollectors(IMongoDatabase database)
            : base(database)
        {
        }

        public IEnumerable<InvalidCaseReportFromUnknownDataCollector> GetAll()
        {
            return GetMany(_ => true);
        }
        public IEnumerable<InvalidCaseReportFromUnknownDataCollector> GetByPhoneNumber(string phoneNumber)
        {
            return GetMany(r => r.PhoneNumber == phoneNumber);
        }

        public void SaveInvalidReportFromUnknownDataCollector(CaseReportId caseReportId, string message, string origin,
            IEnumerable<string> errorMessages, DateTimeOffset timestamp)
        {
            Update(new InvalidCaseReportFromUnknownDataCollector(caseReportId)
            {
                Message = message,
                ParsingErrorMessage = errorMessages,
                PhoneNumber = origin,
                Timestamp = timestamp
            });
        }
    }
}
