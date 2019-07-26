/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Concepts;
using Concepts.HealthRisks;
using Dolittle.ReadModels;

namespace Read.CaseReports
{
    public class CaseReportsPerHealthRiskPerDay : IReadModel
    {
        public Day Id { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public Dictionary<HealthRiskName, Dictionary<RegionName, int>> ReportsPerHealthRisk { get; set; }
    }
}
