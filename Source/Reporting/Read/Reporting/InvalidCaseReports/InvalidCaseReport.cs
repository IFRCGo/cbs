/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Concepts.CaseReports;
using Concepts.DataCollectors;
using Dolittle.ReadModels;

namespace Read.Reporting.InvalidCaseReports
{
    public class InvalidCaseReport : IReadModel
    {
        public CaseReportId Id { get; set; }
        public DataCollectorId DataCollectorId { get; set; }
        public string Origin { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> ParsingErrorMessage { get; set; }
        public DateTimeOffset Timestamp { get; set; }

        public InvalidCaseReport(CaseReportId id) => Id = id;
    }
}
