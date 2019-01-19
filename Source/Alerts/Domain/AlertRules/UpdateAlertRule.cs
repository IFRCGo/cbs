/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.AlertRules;
using Concepts.HealthRisks;
using Dolittle.Commands;

namespace Domain.AlertRules
{
    public class UpdateAlertRule : ICommand
    {
        public RuleId Id { get; set; }
        public AlertRuleName AlertRuleName { get; set; }

        public NumberOfCasesThreshold NumberOfCasesThreshold { get; set; }
        public ThresholdTimeframeInHours ThresholdTimeframeInHours { get; set; }
        public HealthRiskNumber HealthRiskNumber { get; set; }
        public DistanceBetweenCasesInMeters DistanceBetweenCasesInMeters { get; set; }
    }
}