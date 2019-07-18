/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.Alerts;
using Concepts.HealthRisks;
using Dolittle.ReadModels;

namespace Read.Alerts
{
    public class Alert : IReadModel
    {
        public AlertId Id { get; set; }
        public AlertRuleId AlertRuleId { get; set; }
        public HealthRiskName HealthRiskName { get; set; }
        public uint AlertNumber { get; set; }
    }
}
