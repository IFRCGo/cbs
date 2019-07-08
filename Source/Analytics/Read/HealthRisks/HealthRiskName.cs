/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using Concepts.HealthRisks;
using Dolittle.ReadModels;
using HealthRiskNameConcept = Concepts.HealthRisks.HealthRiskName;

namespace Read.HealthRisks
{
    public class HealthRiskName : IReadModel
    {
        public HealthRiskId Id { get; set; }
        public HealthRiskNameConcept Name { get; set; }
    }
}
