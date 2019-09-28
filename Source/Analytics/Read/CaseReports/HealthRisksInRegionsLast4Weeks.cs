/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using Dolittle.ReadModels;
using System.Collections.Generic;
using Concepts.HealthRisks;
using Concepts;

namespace Read.CaseReports
{
    public class HealthRisksInRegionsLast4Weeks : IReadModel
    {
        public Dictionary<RegionName, RegionWithHealthRisk> Regions { get; set; }
    }
}