/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Concepts.AlertRules;
using Dolittle.ReadModels;

namespace Read.AlertRules
{
    public class AlertRule: IReadModel
    {
        public RuleId Id { get; set; }
        public string AlertRuleName { get; set; }
        public int HealthRiskId { get; set; }
        public int NumberOfCasesThreshold { get; set; }
        public int DistanceBetweenCasesInMeters { get; set; }
        public int ThresholdTimeframeInHours { get; set; }
    }
}