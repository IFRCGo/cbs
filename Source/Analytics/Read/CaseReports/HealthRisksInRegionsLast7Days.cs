/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using Dolittle.ReadModels;
using System.Collections.Generic;
using Concepts.HealthRisks;

namespace Read.CaseReports
{
    public class HealthRisksInRegionsLast7Days : IReadModel
    {
        public HealthRiskId Id { get; set; }
        public HealthRiskName HealthRiskName { get; set; }
        public IList<RegionWithHealthRisk> Regions { get; set; }
    }
}