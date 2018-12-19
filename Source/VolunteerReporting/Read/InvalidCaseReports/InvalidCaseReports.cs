/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Concepts.CaseReport;
using Concepts.DataCollector;

namespace Read.InvalidCaseReports
{
    public class InvalidCaseReports : ExtendedReadModelRepositoryFor<InvalidCaseReport>, 
        IInvalidCaseReports
    {
        public InvalidCaseReports(IMongoDatabase database)
            : base(database)
        {
        }


        public IEnumerable<InvalidCaseReport> GetAll()
        {
            return GetMany(_ => true);
        }
        public void SaveInvalidReport(CaseReportId caseReportId, DataCollectorId dataCollectorId, string message, string origin,
            IEnumerable<string> errorMessages, DateTimeOffset timestamp)
        {
            Update(new InvalidCaseReport(caseReportId)
            {
                DataCollectorId = dataCollectorId,
                Message = message,
                Origin = origin,
                ParsingErrorMessage = errorMessages,
                Timestamp = timestamp
            });
        }
    }
}
