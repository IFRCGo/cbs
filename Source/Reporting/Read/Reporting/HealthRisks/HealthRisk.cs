/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Concepts.HealthRisks;
using Dolittle.ReadModels;

namespace Read.Reporting.HealthRisks
{
    public class HealthRisk : IReadModel
    {
        public HealthRiskId Id { get; set; }

        public HealthRiskReadableId ReadableId { get; set; }
        public string Name { get; set; }

        public HealthRisk(Guid id)
        {
            Id = id;
        }
    }
}
