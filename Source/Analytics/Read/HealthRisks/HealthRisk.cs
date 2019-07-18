/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using Dolittle.ReadModels;
using Concepts.HealthRisks;

namespace Read.HealthRisks
{
    public class HealthRisk : IReadModel
    {
        public HealthRiskId Id { get; set; }
        public HealthRiskName Name { get; set; }
        public HealthRiskNumber HealthRiskNumber { get; set; }
    }
}