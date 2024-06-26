/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Concepts.CaseReports;
using Concepts.DataCollectors;
using Concepts.HealthRisks;
using Dolittle.ReadModels;

namespace Read.Reporting.CaseReports
{
    public class CaseReport : IReadModel
    {
        public CaseReportId Id { get; set; }

        public string Message { get; set; }
        public DataCollectorId DataCollectorId { get; set ; }
        public HealthRiskId HealthRiskId { get; set; }
        public int NumberOfFemalesAged5AndOlder { get; set; }
        public int NumberOfFemalesUnder5 { get; set; }
        public int NumberOfMalesAged5AndOlder { get; set; }
        public int NumberOfMalesUnder5 { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public Location Location { get; set; }
        public string Region { get; set; }

        public CaseReport(CaseReportId id)
        {
            Id = id;
        }
    }
}