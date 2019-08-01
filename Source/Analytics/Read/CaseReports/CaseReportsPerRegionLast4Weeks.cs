/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using Concepts;
using Dolittle.ReadModels;
using System.Collections.Generic;

namespace Read.CaseReports
{
    public class CaseReportsPerRegionLast4Weeks : IReadModel
    {
        public Day Id { get; set; }
        public IList<HealthRisksInRegionsLast4Weeks> HealthRisks { get; set; }
    }
}